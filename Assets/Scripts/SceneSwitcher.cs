using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    private bool isLoading;
    private static SceneSwitcher instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SwitchScene(string scene)
    {
        if (isLoading)
        {
            return;
        }

        var currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == scene)
        {
            throw new Exception("You are trying to load already loaded scene.");
        }

        if (scene == "SinglePlayerGame" || scene == "MultiplayerGame")
        {
            PlayerPrefs.DeleteKey("pScore");
            PlayerPrefs.DeleteKey("eScore");
        }

        Time.timeScale = 1.0f;

        StartCoroutine(LoadSceneRoutine(scene));
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadSceneRoutine(string scene)
    {
        isLoading = true;

        var waitFading = true;

        Fader.Instance.FadeIn(() => waitFading = false);

        while (waitFading)
        {
            yield return null;
        }

        var async = SceneManager.LoadSceneAsync(scene);
        
        waitFading = true;
        Fader.Instance.FadeOut(() => waitFading = false);

        while (waitFading)
        {
            yield return null;
        }

        isLoading = false;
    }
}
