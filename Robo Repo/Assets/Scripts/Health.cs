using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int maxHealth = 1;
    private int health = 1;
    public Image health1;
    public Image health2;
    public Image health3;
    public Image health4;
    public Sprite EmptyHealth;


    private void Start()
    {
        health2.enabled = false;
        health3.enabled = false;
        health4.enabled = false;
    }

    void OnCollisionEnter2D(Collider thing)
    {
        if (thing.CompareTag("Enemy"))
        {
            health = health - 1;
            if (health == 0)
                StartCoroutine("death");
        }
        else if (thing.CompareTag("PartA") || thing.CompareTag("PartB") || thing.CompareTag("PartC"))
        {
            maxHealth = maxHealth + 1;
            health = health + 1;
        }
        else if (thing.CompareTag("Gear") && (health < maxHealth))
        {
            thing.enabled = false;
            health = health + 1;
        }
    }

    void Update()
    {
        if (health == 1)
        {
            health1.enabled = true;
        }
        else if (maxHealth == 2)
        {
            health1.enabled = true;
            health2.enabled = true;
        }
        else if (maxHealth == 3)
        {
            health1.enabled = true;
            health2.enabled = true;
            health3.enabled = true;
        }
        else if (maxHealth == 4)
        {
            health1.enabled = true;
            health2.enabled = true;
            health3.enabled = true;
            health4.enabled = true;
        }

    }

    IEnumerator death()
    {
        health1.setactive
        SceneManager.LoadScene(SceneManager.GetActiveScene());
    }
}
