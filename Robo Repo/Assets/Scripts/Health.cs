﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int maxHealth = 1;
    private int health;
    public Image[] healthImage;
    public Sprite healthSprite;
    public Movement movement;
    public GameObject winText;
    public Color white;
    public Color grey;
    private void Start()
    {
        for(int i = 1; i <= 4; i += 1)
        {
            healthImage[i - 1] = healthImage[i - 1] == null ? GameObject.Find("Health" + i.ToString()).GetComponent<Image>() : healthImage[i - 1];
        }
        movement = movement == null ? GameObject.Find("Player").GetComponent<Movement>() : movement;
        health = maxHealth;
        for(int i = 1; i < 4; i += 1)
        {
            healthImage[i].color = grey;
            healthImage[i].enabled = false;
        }
        UpdateHealth();
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        Debug.Log("Collided with " + thing.gameObject.name);
        if (thing.gameObject.CompareTag("Enemy"))
        {
            if(thing.gameObject.GetComponent<Animator>() != null && !movement.isGrounded)
            {
                thing.gameObject.GetComponent<Animator>().SetTrigger("Squish");
                if(thing.gameObject.GetComponent<EnemyFollow>() != null)
                {
                    thing.gameObject.GetComponent<EnemyFollow>().isDead = true;
                }
                Collider2D[] temp = thing.gameObject.GetComponents<PolygonCollider2D>();
                for(int i = 0; i < temp.Length; i += 1)
                {
                    temp[i].enabled = false;
                }
                thing.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                thing.tag = "Untagged";
            }
            else
            {
                health -= 1;
                UpdateHealth();
                if (health == 0)
                {
                    StartCoroutine("Death");
                }
            }

        }
        else if (thing.gameObject.CompareTag("Part") && maxHealth + 1 <= healthImage.Length)
        {
            Destroy(thing.gameObject);
            maxHealth += 1;
            health += 1;
            UpdateHealth();
        }
        else if (thing.gameObject.CompareTag("Gear") && (health < maxHealth))
        {
            Destroy(thing.gameObject);
            health += 1;
            UpdateHealth();
        }
        else if(thing.gameObject.CompareTag("House"))
        {
            StartCoroutine(Win());
        }
        else if(thing.gameObject.CompareTag("Kill"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void UpdateHealth()
    {
        for(int i = maxHealth - 1; i < maxHealth; i += 1)
        {
            healthImage[i].enabled = true;
        }
        for(int i = health - 2; i <= health; i += 1)
        {
            if(i >= 0)
            {
                healthImage[i].color = i == health ? grey : white;
            }
        }
    }
    IEnumerator Death()
    {
        movement.isDead = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator Win()
    {
        winText.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
