using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   
    [SerializeField]private bool damageable = true;
    [SerializeField]private int healthAmount = 1;
    [SerializeField]private float invulnerabilityTime = .2f;
    [SerializeField]private bool isEnemy;
    private bool hit;
    private int currentHealth;
    private Animator animator;
    private KnockbackTrigger knockbackTrigger;

    private void Start()
    {
        currentHealth = healthAmount;
        knockbackTrigger = GetComponent<KnockbackTrigger>(); 
    }

    public void doDamage(int amount, Transform kbOrigin, bool isDown)
    {
        if (damageable && !hit && currentHealth > 0)
        {
            hit = true;
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                Death();
                if(isEnemy)
                {    
                   
                }
            }
            else
            {
                StartCoroutine(TurnOffHit());
                if(isEnemy)
                {
                    if(isDown)
                    {
                        knockbackTrigger.ReverseKnockback(kbOrigin);
                    }
                    else
                    {
                        knockbackTrigger.Knockback(kbOrigin);
                    }

                    GetComponent<HitColor>().ChangeToHitColor();
                }
            }
        }
    }

    private IEnumerator TurnOffHit()
    {
        yield return new WaitForSeconds(invulnerabilityTime);
        hit = false;
    }

    private void Death()
    {
        currentHealth = 0;
        if(isEnemy)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<EnemyAttack>().enabled = false;
            GetComponent<HealthDrop>().EnemyDrop();
            GetComponents<BoxCollider2D>()[0].enabled = false;
            GetComponents<BoxCollider2D>()[1].enabled = false;
            
            if(GetComponent<EnemyWalking>())
            {
                GetComponent<EnemyWalking>().enabled = false;
            }
            if(GetComponent<EnemyChase>())
            {
                GetComponent<EnemyChase>().enabled = false;
            }
            GetComponent<Animator>().SetTrigger("dead"); 
        }
        else
        {
            DisableEnemy();
        }
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}