using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackTrigger : MonoBehaviour
{
    [SerializeField] private float kbTime = 0.2f;
    [SerializeField] private float kbVelocity;
    private Vector3 kbDir;
    private Rigidbody2D body;

    public void Knockback(Transform knocker)
    {
        kbDir = transform.position - knocker.transform.position;
        GetComponent<Rigidbody2D>().velocity = kbDir.normalized * kbVelocity;
        StartCoroutine(clearVelocity());
    }

    private IEnumerator clearVelocity()
    {
        yield return new WaitForSeconds(kbTime);
        GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
    }

    public void ReverseKnockback(Transform knocker)
    {
        //kbDir = knocker.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = kbDir.normalized * kbVelocity;
        body = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        body.velocity = new Vector3(body.velocity.x, kbVelocity, 0);
    }
}
