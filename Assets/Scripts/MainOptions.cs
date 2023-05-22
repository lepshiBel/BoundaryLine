using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainOptions : MonoBehaviour
{
    public ToggleGroup themeToggleGroup;
    public ToggleGroup controlToggleGroup;

    public Toggle darkToggle;
    public Toggle lightToggle;

    public Toggle tiltToggle;
    public Toggle dragToggle;

    private string toggleGroupKey1 = "ToggleGroupState1";
    private string toggleGroupKey2 = "ToggleGroupState2";

    private void Start()
    {
        if (PlayerPrefs.HasKey(toggleGroupKey1))
        {
            int index = PlayerPrefs.GetInt(toggleGroupKey1);
            Toggle[] toggles = themeToggleGroup.GetComponentsInChildren<Toggle>();
            if (index >= 0 && index < toggles.Length)
            {
                toggles[index].isOn = true;
            }
        }

        if (PlayerPrefs.HasKey(toggleGroupKey2))
        {
            int index = PlayerPrefs.GetInt(toggleGroupKey2);
            Toggle[] toggles = controlToggleGroup.GetComponentsInChildren<Toggle>();
            if (index >= 0 && index < toggles.Length)
            {
                toggles[index].isOn = true;
            }
        }

        Toggle[] allThemeToggles = themeToggleGroup.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < allThemeToggles.Length; i++)
        {
            int index = i;
            allThemeToggles[i].onValueChanged.AddListener((isOn) => OnThemeToggleValueChanged(isOn, index));
        }

        Toggle[] allControlToggles = controlToggleGroup.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < allControlToggles.Length; i++)
        {
            int index = i;
            allControlToggles[i].onValueChanged.AddListener((isOn) => OnControlToggleValueChanged(isOn, index));
        }
    }

    private void OnThemeToggleValueChanged(bool isOn, int index)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt(toggleGroupKey1, index);
            PlayerPrefs.Save();
        }
    }

    private void OnControlToggleValueChanged(bool isOn, int index)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt(toggleGroupKey2, index);
            PlayerPrefs.Save();
        }
    }
}
