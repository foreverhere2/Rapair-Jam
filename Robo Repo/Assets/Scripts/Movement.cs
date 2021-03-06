﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Animator thisAnim;
    public SpriteRenderer spriteRenderer;
    public bool isDead = false;
    public float speed;
    public float torsoSpeed;
    public float jump;
    public float torsoJump;
    public float legJump;

    public CircleCollider2D headCol, torsoCol1, legCol1;
    public PolygonCollider2D torsoCol2, legCol2;

    public BoxCollider2D punchBox;

    float moveVelocity;


    [HideInInspector] public bool isGrounded = true;

    private void Start()
    {
        rigidBody = rigidBody == null ? gameObject.GetComponent<Rigidbody2D>() : rigidBody;
        thisAnim = thisAnim == null ? gameObject.GetComponent<Animator>() : thisAnim;
        spriteRenderer = spriteRenderer == null ? gameObject.GetComponent<SpriteRenderer>() : spriteRenderer;

        torsoCol1.enabled = false;
        torsoCol2.enabled = false;
        legCol1.enabled = false;
        legCol2.enabled = false;

        punchBox.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded && !isDead)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = Vector2.right * (!isDead ? -speed : rigidBody.velocity.x) + Vector2.up * rigidBody.velocity.y;
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = Vector2.right * (!isDead ? speed : rigidBody.velocity.x) + Vector2.up * rigidBody.velocity.y;
            spriteRenderer.flipX = false;
        }
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)))
        {
            rigidBody.velocity = Vector2.up * rigidBody.velocity.y;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("Punching");
        }

        thisAnim.SetFloat("DirX", ( rigidBody.velocity.x != 0 ? speed / rigidBody.velocity.x : 0));
        thisAnim.SetFloat("DirY", (rigidBody.velocity.y != 0 ? jump / rigidBody.velocity.y : 0));
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.CompareTag("Part"))
        {
            if (thing.gameObject.name == "Arms")
            {
                StartCoroutine("Arms");
            }
            else if (thing.gameObject.name == "Legs")
            {
                jump = legJump;

                StartCoroutine("Legs");

                torsoCol1.enabled = false;
                torsoCol2.enabled = false;
                legCol1.enabled = true;
                legCol2.enabled = true;
            }
            else if (thing.gameObject.name == "Torso")
            {
                speed = torsoSpeed;
                jump = torsoJump;

                StartCoroutine("Torso");

                headCol.enabled = false;
                torsoCol1.enabled = true;
                torsoCol2.enabled = true;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    IEnumerator Punching()
    {
        thisAnim.SetBool("isPunching", true);
        punchBox.enabled = true;
        yield return new WaitForSeconds(1f);
        punchBox.enabled = false;
        thisAnim.SetBool("isPunching", false);
    }

    IEnumerator Legs()
    {
        thisAnim.SetTrigger("LegsAquisition");
        isDead = true;
        yield return new WaitForSeconds(1.5f);
        isDead = false;
        thisAnim.SetTrigger("FinishAnim");
    }

    IEnumerator Arms()
    {
        thisAnim.SetTrigger("ArmsAquisition");
        isDead = true;
        yield return new WaitForSeconds(2f);
        isDead = false;
        thisAnim.SetTrigger("FinishAnim");
    }

    IEnumerator Torso()
    {
        thisAnim.SetTrigger("TorsoAquisition");
        isDead = true;
        yield return new WaitForSeconds(2f);
        isDead = false;
        thisAnim.SetTrigger("FinishAnim");
    }
}