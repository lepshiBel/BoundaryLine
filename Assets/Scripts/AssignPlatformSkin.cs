using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPlatformSkin : MonoBehaviour
{
    public Renderer platform;

    // Start is called before the first frame update
    void Start()
    {
        if (ThemeManager.CurrentTheme == Theme.Light)
        {
            platform.material.color = Color.black;
        }
        else if (ThemeManager.CurrentTheme == Theme.Dark && PlayerPrefs.GetInt("platformSkinNum") == 0)
        {
            platform.material.color = Color.white;
        }
        else if (PlayerPrefs.GetInt("platformSkinNum") == 1)
        {
            platform.material.color = Color.red;
        }
        else if (PlayerPrefs.GetInt("platformSkinNum") == 2)
        {
            platform.material.color = Color.green;
        }
        else if (PlayerPrefs.GetInt("platformSkinNum") == 3)
        {
            platform.material.color = Color.cyan;
        }
        else if (PlayerPrefs.GetInt("platformSkinNum") == 4)
        {
            platform.material.color = Color.blue;
        }
        else if (PlayerPrefs.GetInt("platformSkinNum") == 5)
        {
            platform.material.color = Color.magenta;
        }
    }
}
