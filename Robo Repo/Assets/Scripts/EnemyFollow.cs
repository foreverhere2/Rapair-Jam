using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public bool isDead = false;
    public Animator animator;
    public Transform target;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        target = target == null ? GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>() : target;
        animator = animator == null ? gameObject.GetComponent<Animator>() : animator;
        rigidBody = rigidBody == null ? gameObject.GetComponent<Rigidbody2D>() : rigidBody;
        spriteRenderer = spriteRenderer == null ? gameObject.GetComponent<SpriteRenderer>() : spriteRenderer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < 8 && !isDead)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.right * target.position.x + Vector2.up * transform.position.y, speed * Time.deltaTime);
        }
        spriteRenderer.flipX = (target.position.x - transform.position.x) > 0 ? false : (target.position.x - transform.position.x) < 0 ? true : spriteRenderer.flipX;
    }
}
