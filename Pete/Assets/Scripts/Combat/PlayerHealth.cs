using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Move move;
    private Rigidbody2D body;

    [SerializeField] private int playerHP;

    [SerializeField] private float kbForce;
    [SerializeField] private float kbTime;
    private float kbCounter;

    private void Start() 
    {
        move = GetComponent<Move>(); 
        body = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        kbCounter -= Time.deltaTime;
        if(kbCounter > 0)
            move.canMove = false;
        else
            move.canMove = true;
    }

    public void PlayerDamage(int damage, bool kbRight)
    {
        playerHP -= damage;
        if(kbRight)
            body.velocity = new Vector2(-kbForce, kbForce*7);
        else   
            body.velocity = new Vector2(kbForce, kbForce*7);

        kbCounter = kbTime;
    }
}
