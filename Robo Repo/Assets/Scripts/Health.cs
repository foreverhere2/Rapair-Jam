using System.Collections;
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
    public Color white;
    public Color grey;
    private void Start()
    {
        for(int i = 1; i <= 4; i += 1)
        {
            healthImage[i - 1] = healthImage[i - 1] == null ? GameObject.Find("Health" + i.ToString()).GetComponent<Image>() : healthImage[i - 1];
        }
        healthSprite = healthSprite == null ? (Sprite)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Sprites/Health.png", typeof(Sprite)) : healthSprite;
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
            health -= 1;
            UpdateHealth();
            if (health == 0)
                StartCoroutine("Death");
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
}
