using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignBallLightSkin : MonoBehaviour
{
    public GameObject ballLight;

    // Start is called before the first frame update
    void Start()
    {
        if (ThemeManager.CurrentTheme == Theme.Light && PlayerPrefs.GetInt("lightSkinNum") == 0 && PlayerPrefs.GetInt("mapSkinNum") == 1)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.black;
        }
        else if (PlayerPrefs.GetInt("lightSkinNum") == 0)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.yellow;
        }
        else if (PlayerPrefs.GetInt("lightSkinNum") == 1)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.red;
        }
        else if (PlayerPrefs.GetInt("lightSkinNum") == 2)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.green;
        }
        else if (PlayerPrefs.GetInt("lightSkinNum") == 3)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.cyan;
        }
        else if (PlayerPrefs.GetInt("lightSkinNum") == 4)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.blue;
        }
        else if (PlayerPrefs.GetInt("lightSkinNum") == 5)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.magenta;
        }
    }
}
