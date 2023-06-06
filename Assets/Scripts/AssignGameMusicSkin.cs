using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignGameMusicSkin : MonoBehaviour
{
    public MusicContainer MusicContainer;
    
    public void ChooseMusicSkin()
    {
        if (PlayerPrefs.GetInt("gameMusicSkinNum") == 0)
        {
            BackgroundMusic.Instance.ChangeAudioClip(MusicContainer.audioClips[1]);
        }
        else if (PlayerPrefs.GetInt("gameMusicSkinNum") == 1)
        {
            BackgroundMusic.Instance.ChangeAudioClip(MusicContainer.audioClips[2]);
        }
        else if (PlayerPrefs.GetInt("gameMusicSkinNum") == 2)
        {
            BackgroundMusic.Instance.ChangeAudioClip(MusicContainer.audioClips[3]);
        }
        else if (PlayerPrefs.GetInt("gameMusicSkinNum") == 3)
        {
            BackgroundMusic.Instance.ChangeAudioClip(MusicContainer.audioClips[4]);
        }
        else if (PlayerPrefs.GetInt("gameMusicSkinNum") == 4)
        {
            BackgroundMusic.Instance.ChangeAudioClip(MusicContainer.audioClips[5]);
        }
        else if (PlayerPrefs.GetInt("gameMusicSkinNum") == 5)
        {
            BackgroundMusic.Instance.ChangeAudioClip(MusicContainer.audioClips[6]);
        }
    }
}
