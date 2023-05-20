using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainOptions : MonoBehaviour
{
    public ToggleGroup toggleGroup;

    public Toggle toggle1;
    public Toggle toggle2;

    private string toggleGroupKey = "ToggleGroupState";

    private void Start()
    {
        if (PlayerPrefs.HasKey(toggleGroupKey))
        {
            int index = PlayerPrefs.GetInt(toggleGroupKey);
            Toggle[] toggles = toggleGroup.GetComponentsInChildren<Toggle>();
            if (index >= 0 && index < toggles.Length)
            {
                toggles[index].isOn = true;
            }
        }

        Toggle[] allToggles = toggleGroup.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < allToggles.Length; i++)
        {
            int index = i;
            allToggles[i].onValueChanged.AddListener((isOn) => OnToggleValueChanged(isOn, index));
        }
    }

    private void OnToggleValueChanged(bool isOn, int index)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt(toggleGroupKey, index);
            PlayerPrefs.Save();
        }
    }
}
