using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
   private int weaponDamage;
   private Component parentTransform;

    private void Awake() 
    {
        weaponDamage = GetComponentInParent<MeleeAttackManager>().meleeDamage;   
        parentTransform = GetComponentInParent<Transform>();
        Debug.Log(weaponDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.GetComponent<EnemyHealth>())
        {
            Debug.Log("Enemy hit");
            collision.GetComponent<EnemyHealth>().doDamage(weaponDamage);
            //Beim stehen bleiben kann man nur einmal angreifen weil OnTriggerEnter2D nur beim erstmaligen betreten funktioniert.
            //Absolut schrecklicher weg das Problem zu lösen
            parentTransform.transform.localPosition = new Vector3(parentTransform.transform.localPosition.x, parentTransform.transform.localPosition.y + 0.00001f, parentTransform.transform.localPosition.z);
        }
    }

    private void OnDisable() 
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnEnable()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}