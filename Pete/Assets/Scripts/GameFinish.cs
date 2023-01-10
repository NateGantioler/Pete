using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<PowerStatus>().Powers >= 2)
            {
                GameFinished();
            }
        }    
    }

    private void GameFinished()
    {
        GameObject.FindGameObjectWithTag("TimerManager").GetComponent<TimerManager>().StopTimer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
