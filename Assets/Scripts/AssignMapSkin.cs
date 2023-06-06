using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignMapSkin : MonoBehaviour
{
    public GameObject[] backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("mapSkinNum") == 0)
        {
            ChangeBackground(0);
        }
        else if (PlayerPrefs.GetInt("mapSkinNum") == 1)
        {
            ChangeBackground(1);
        }
        else if (PlayerPrefs.GetInt("mapSkinNum") == 2)
        {
            ChangeBackground(2);
        }
        else if (PlayerPrefs.GetInt("mapSkinNum") == 3)
        {
            ChangeBackground(3);
        }
        else if (PlayerPrefs.GetInt("mapSkinNum") == 4)
        {
            ChangeBackground(4);
        }
        else if (PlayerPrefs.GetInt("mapSkinNum") == 5)
        {
            ChangeBackground(5);
        }
    }

    private void ChangeBackground(int bgNumber)
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (i == bgNumber)
            {
                backgrounds[i].SetActive(true);
            }
            else
            {
                backgrounds[i].SetActive(false);
            }
        }
    }
}
