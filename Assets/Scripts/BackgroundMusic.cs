using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance { get; private set; }
    public AudioSource audioSource;

    public MusicContainer MusicContainer;
    public AssignGameMusicSkin gameMusic;
    private bool menuMusicIsPlaying = false;
    private bool gameMusicIsPlaying = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        if (scene.name == "MainMenu" && !menuMusicIsPlaying)
        {
            Instance.ChangeAudioClip(MusicContainer.audioClips[0]);
            menuMusicIsPlaying = true;
            gameMusicIsPlaying = false;
        }
        if ((scene.name == "SinglePlayerGame" || scene.name == "MultiplayerGame") && !gameMusicIsPlaying)
        {
            gameMusic.ChooseMusicSkin();
            menuMusicIsPlaying = false;
            gameMusicIsPlaying = true;
        }
    }

    public void ChangeAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
