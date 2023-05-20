using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSkin : MonoBehaviour
{
    public GameObject ballLight;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("skinNum") == 1)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.red;
        }
        else if (PlayerPrefs.GetInt("skinNum") == 2)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.green;
        }
        else if (PlayerPrefs.GetInt("skinNum") == 3)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.cyan;
        }
        else if (PlayerPrefs.GetInt("skinNum") == 4)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.blue;
        }
        else if (PlayerPrefs.GetInt("skinNum") == 5)
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.magenta;
        }
        else
        {
            ballLight.GetComponent<HardLight2D>().Color = Color.yellow;
        }
    }
}
