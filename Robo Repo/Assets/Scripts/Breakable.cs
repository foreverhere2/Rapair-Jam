using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    public Animator thisAnim;
    public PolygonCollider2D thisCollider;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerPunch"))
        {
            thisAnim.SetBool("isDestroyed", true);
            thisCollider.enabled = false;
        }
    }
}
