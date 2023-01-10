using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RESETLEVEL();
        }
    }

    public static void RESETLEVEL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
