using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer sprite;

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
       if(body.velocity.x > 0)
       {
            sprite.flipX = false;
       }
       else if(body.velocity.x < 0)
       {
            sprite.flipX = true;
       }
       
    }
}
