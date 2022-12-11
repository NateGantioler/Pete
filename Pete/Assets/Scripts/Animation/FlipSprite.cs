using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private bool spriteFlipped = false;
    private float standardScale;

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>();
        standardScale = body.transform.localScale.x;
    }
    
    void Update()
    {
       if(body.velocity.x > 0)
       {
            body.transform.localScale = new Vector3(standardScale, body.transform.localScale.y, body.transform.localScale.x);
            spriteFlipped = false;
       }
       else if(body.velocity.x < 0)
       {
            body.transform.localScale = new Vector3((-1) * standardScale, body.transform.localScale.y, body.transform.localScale.x);
            spriteFlipped = true;
       }
    }

    public bool isFlipped()
    {
        return spriteFlipped;
    }
}
