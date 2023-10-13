using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseOverlay;    
    private bool isPaused = false; 
    private float gameSpeed = 1f;
    [SerializeField] private TMP_InputField gameSpeedInput;

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

    public void Resume()
    {
        pauseOverlay.SetActive(false);
        Time.timeScale = gameSpeed;
        isPaused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void gameSpeedChanged()
    {
        gameSpeed = float.Parse(gameSpeedInput.text);
        Debug.Log("Cjanh asp");
    }
}
