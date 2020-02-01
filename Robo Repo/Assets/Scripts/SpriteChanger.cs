using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public GameObject playerModel;
    public Sprite head, torso, legs, arms;
    public Animation anim;


    private void OnCollisionEnter2D(Collision2D part)
    {
        if (part.gameObject.name == "Arms")
        {

        }
        else if (part.gameObject.name == "Legs")
        {

        }
        else if (part.gameObject.name == "Torso")
        {

        }
    }



    /* Start is called before the first frame update
    void Start()
    {
        change = GetComponent<SpriteRenderer>();
        square = Resources.Load<Sprite>("square");
        triangle = Resources.Load<Sprite>("triangle");
        change.sprite = square;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {



        if (change.sprite == square)
        {
            change.sprite = triangle;
        }

    }*/
}

