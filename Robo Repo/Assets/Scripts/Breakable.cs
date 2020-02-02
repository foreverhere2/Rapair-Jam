using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    public Animator thisAnim;
    public PolygonCollider2D thisCollider;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine("Destroyed");
        }
    }

    IEnumerator Destroyed()
    {
        thisAnim.SetBool("isDestroyed", true);
        yield return new WaitForSeconds(2f);
        thisCollider.enabled = false;
    }
}
