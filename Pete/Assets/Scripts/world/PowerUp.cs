using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject oneMore;
    [SerializeField] private GameObject returnStart;
    private bool hasGivenPower = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Collect(other);
            GetComponent<SpriteRenderer>().enabled = false;
        }    
    }

    private void Collect(Collider2D player) 
    {
        if(!hasGivenPower)
        {
            player.GetComponent<PowerStatus>().Powers++;
            AudioManager.Instance.PlaySound("O_FlyOrb");
            hasGivenPower = true;
        }
        if(player.GetComponent<PowerStatus>().Powers == 1)
        {
            oneMore.SetActive(true);
            //Invoke("DisableScreen", 5f);
            StartCoroutine(DisableText());
        }
        else if(player.GetComponent<PowerStatus>().Powers == 2)
        {
            returnStart.SetActive(true);
            //Invoke("DisableScreen", 5f);
            StartCoroutine(DisableText());
        }
    }

    private void DiscableScreen()
    {
        oneMore.SetActive(false);
        returnStart.SetActive(false);
    }

    private IEnumerator DisableText()
    {
        yield return new WaitForSeconds(5);
        oneMore.SetActive(false);
        returnStart.SetActive(false);
        hasGivenPower = false;
    }
}
