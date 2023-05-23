using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeInit : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;

    private void Start()
    {
        var volumeValue = PlayerPrefs.GetFloat(volumeParameter, -40f);
        mixer.SetFloat(volumeParameter, volumeValue);
    }
}
