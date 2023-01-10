using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoreTimer : MonoBehaviour
{
    private int minutes;
    private int seconds;
    private int fraction;
    private GameObject finishTimeText;

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;    
    }

    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;    
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if(scene.name == "End")
        {
            DisplayFinishTime();
        }
    }

    public void setFinishTime(int minutes, int seconds, int fraction)
    {
        this.minutes = minutes;
        this.seconds = seconds;
        this.fraction = fraction;
    }

    public void DisplayFinishTime()
    {
        finishTimeText = GameObject.FindGameObjectWithTag("FinishTimeText");
        finishTimeText.GetComponent<TMP_Text>().text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }
}
