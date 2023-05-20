using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public static bool gameIsPaused = false;
    public static bool pauseIsClicked = false;

    // Update is called once per frame
    void Update()
    {
        if (pauseIsClicked)
        {
            pauseIsClicked = false;
            
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }      
    }

    public void TaskOnPauseButtonClick()
    {
        pauseIsClicked = true;
    }

    public void Resume()
    {    
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false; 
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f;
        gameIsPaused = true; 
    }
}
