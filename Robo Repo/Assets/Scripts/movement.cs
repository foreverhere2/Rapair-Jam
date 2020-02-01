using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public bool isDead = false;
    public float speed;
    public float jump;
    float moveVelocity;


    bool isGrounded = true;

    void Update()
    {
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if (isGrounded)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                    isGrounded = false;
                }
            }

            moveVelocity = 0;


            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                moveVelocity = -speed;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                moveVelocity = speed;
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        }
        else {

        }
    }

    void OnCollisionEnter2D()
    {
        isGrounded = true;
    }
}