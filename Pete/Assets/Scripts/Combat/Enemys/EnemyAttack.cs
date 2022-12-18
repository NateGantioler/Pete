using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackDelay;
    private float currentAttackDelay = 0;

    public void DamagePlayer(Collider2D other) 
    {
        if(currentAttackDelay <= 0)
        {
            if(other.transform.localPosition.x < transform.localPosition.x)
            {
                other.gameObject.GetComponent<PlayerHealth>().PlayerDamage(damage, true);
            }
            else
            {
                other.gameObject.GetComponent<PlayerHealth>().PlayerDamage(damage, false);
            }
            currentAttackDelay = attackDelay; 
        }
    }

    private void Update() 
    {
        currentAttackDelay -= Time.deltaTime;    
    }
}
