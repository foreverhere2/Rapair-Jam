using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 1;
    public int health = 1;
    public Image health1;
    public Image health2;
    public Image health3;
    public Image health4;
    public Sprite EmptyHealth;
    public Sprite FullHealth;
    public Movement movement;

    private void Start()
    {
        health2.enabled = false;
        health3.enabled = false;
        health4.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        Debug.Log("Collided with " + thing.gameObject.name);
        if (thing.gameObject.CompareTag("Enemy"))
        {
            health -=1;
            if (health == 0)
                StartCoroutine("Death");
        }
        else if (thing.gameObject.CompareTag("Part"))
        {
            Destroy(thing.gameObject);
            maxHealth +=1;
            health +=1;
        }
        else if (thing.gameObject.CompareTag("Gear") && (health < maxHealth))
        {
            Destroy(thing.gameObject);
            health +=1;
        }
    }

    void Update()
    {
        switch (maxHealth)
        {
            case 2:
                health2.enabled = true;
                break;
            case 3:
                health3.enabled = true;
                break;
            case 4:
                health4.enabled = true;
                break;
        }

        switch (health)
        {
            case 1:
                health1.sprite = FullHealth;
                health2.sprite = EmptyHealth;
                health3.sprite = EmptyHealth;
                health4.sprite = EmptyHealth;
                break;
            case 2:
                health1.sprite = FullHealth;
                health2.sprite = FullHealth;
                health3.sprite = EmptyHealth;
                health4.sprite = EmptyHealth;
                break;
            case 3:
                health1.sprite = FullHealth;
                health2.sprite = FullHealth;
                health3.sprite = FullHealth;
                health4.sprite = EmptyHealth;
                break;
            case 4:
                health1.sprite = FullHealth;
                health2.sprite = FullHealth;
                health3.sprite = FullHealth;
                health4.sprite = FullHealth;
                break;
        }

    }

    IEnumerator Death()
    {
        health1.sprite = EmptyHealth;
        movement.enabled = false;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
}
