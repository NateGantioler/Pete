using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseOverlay;    
    private bool isPaused = false; 

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pauseOverlay.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void Resume()
    {
        pauseOverlay.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
