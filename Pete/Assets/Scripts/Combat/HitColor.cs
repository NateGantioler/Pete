using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitColor : MonoBehaviour
{
    [SerializeField] private float hitColorTime;
    private SpriteRenderer spriteRenderer;
   
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeToHitColor()
    {
        spriteRenderer.color = Color.red;
        StartCoroutine(NormalColor());
    }

    private IEnumerator NormalColor()
    {
        yield return new WaitForSeconds(hitColorTime);
        spriteRenderer.color =Color.white;
    }
}
