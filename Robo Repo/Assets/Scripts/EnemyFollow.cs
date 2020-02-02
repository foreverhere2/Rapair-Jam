using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public static float health = 3;

    public Animator animator;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = target == null ? GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>() : target;
        animator = animator == null ? gameObject.GetComponent<Animator>() : animator;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
