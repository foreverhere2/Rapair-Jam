using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private SpriteRenderer change;
    private Sprite player, square;


    // Start is called before the first frame update
    void Start()
    {
      /*  change = GetComponent<SpriteRenderer>();
        player = Resources.Load<Sprite>("player");
        square = Resources.Load<Sprite>("square");
        change.sprite = player;*/
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Movement player = collision.GetComponent<Movement>();

        if (player != null)
        {
            Destroy(gameObject);
           
        }
        /*if (change.sprite == player)
        {
            change.sprite = square;
        }*/

    }
}

