using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healingAmount;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("Player"))
        {
            //other.GetComponent<PlayerHealth>().HealPlayer(healingAmount);
            Destroy(gameObject);
        }  
    }
}
