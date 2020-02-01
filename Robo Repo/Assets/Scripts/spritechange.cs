using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spritechange : MonoBehaviour
{
    private SpriteRenderer change;
    private Sprite square, triangle;


    // Start is called before the first frame update
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

    }
}

