using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healingAmount;
    private bool test = false;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("Player") && test == false)
        {
            test = true;
            other.collider.GetComponent<PlayerHealth>().HealPlayer(healingAmount);
            Destroy(gameObject);
        }  
    }
}
