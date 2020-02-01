using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public bool isDead = false;
    public float speed;
    public float baseJump;
    public float legJump;
    float moveVelocity;


    [HideInInspector] public bool isGrounded = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded && !isDead)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, baseJump);
                isGrounded = false;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = Vector2.right * (!isDead ? -speed : rigidBody.velocity.x) + Vector2.up * rigidBody.velocity.y;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = Vector2.right * (!isDead ? speed : rigidBody.velocity.x) + Vector2.up * rigidBody.velocity.y;
        }
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)))
        {
            rigidBody.velocity = Vector2.up * rigidBody.velocity.y;
        }


    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.gameObject.name == "Arms")
        {

        }
        else if (thing.gameObject.name == "Legs")
            baseJump = legJump;
        else if (thing.gameObject.name == "Torso")
        {

        }
    }
    void OnCollisionEnter2D()
    {
        isGrounded = true;
    }
}