using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   
    [SerializeField]private bool damageable = true;
    [SerializeField]private int healthAmount = 1;
    [SerializeField]private float invulnerabilityTime = .2f;
    private bool hit;
    private int currentHealth;

    private void Start()
    {
        currentHealth = healthAmount;    
    }

    public void doDamage(int amount)
    {
        Debug.Log("Damage Coming");
        if (damageable && !hit && currentHealth > 0)
        {
            Debug.Log("Damage Done");
            hit = true;
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(TurnOffHit());
            }
        }
    }

    private IEnumerator TurnOffHit()
    {
        yield return new WaitForSeconds(invulnerabilityTime);
        hit = false;
    }
}