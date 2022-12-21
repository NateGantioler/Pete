using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private Move move;
    private Rigidbody2D body;
    private KnockbackTrigger knockbackTrigger;
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] private int maxPlayerHP;
    private int playerHP;

    [SerializeField] private float kbForce;
    [SerializeField] private float kbTime;
    private float kbCounter;

    private void Start() 
    {
        move = GetComponent<Move>(); 
        body = GetComponent<Rigidbody2D>();
        knockbackTrigger = GetComponent<KnockbackTrigger>();   
        playerHP = maxPlayerHP;
        RefreshHealthUi();
    }

    private void Update()
    {
        kbCounter -= Time.deltaTime;
        if(kbCounter > 0)
            move.canMove = false;
        else
            move.canMove = true;
    }

    public void PlayerDamage(int damage, Transform kbOrigin)
    {
        playerHP -= damage;
        GetComponent<HitColor>().ChangeToHitColor();
        kbCounter = kbTime;
        knockbackTrigger.Knockback(kbOrigin);
        RefreshHealthUi();
    }

    public void HealPlayer(int healthAmount)
    {
        if(playerHP + healthAmount >= maxPlayerHP)
        {
            playerHP += healthAmount;
        }
        RefreshHealthUi();
    }

    private void RefreshHealthUi()
    {
        healthText.text = "" + playerHP;
    }
}
