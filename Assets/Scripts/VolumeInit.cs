using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeInit : MonoBehaviour
{
    public AudioSource track;
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;

    private void Start()
    {
        if (track.clip.length > 10)
        {
            track.loop = true;
        }

        var volumeValue = PlayerPrefs.GetFloat(volumeParameter, -40f);
        mixer.SetFloat(volumeParameter, volumeValue);
    }
}
