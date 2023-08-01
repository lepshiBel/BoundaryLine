using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public ChangeOrderInLayer changeOrderInLayer;
    public GameObject pauseMenuUI;

    public static bool gameIsPaused;
    public static bool pauseIsClicked;
    public static bool menuIsClicked;

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

        if (menuIsClicked)
        {
            menuIsClicked = false;

            if (gameIsPaused)
            {
                Resume();
            }
        }
    }

    public void TaskOnPauseButtonClick()
    {
        pauseIsClicked = true;
    }

    public void TaskOnMenuButtonClick()
    {
        menuIsClicked = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;

        changeOrderInLayer.RiseOrderInLayers();
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f;
        gameIsPaused = true;

        changeOrderInLayer.LowOrderInLayers();
    }
}
