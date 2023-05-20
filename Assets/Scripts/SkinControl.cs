using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinControl : MonoBehaviour
{
    public int skinNum;
    public Image buyPanel;
    public int price;
    public TextMeshProUGUI itemStateText;
    public RawImage[] skins;

    // Start is called before the first frame update
    void Start()
    {
        buyPanel.color = new Color(0, 0, 0, 0.4f);

        if (PlayerPrefs.GetInt("Skin6" + "buy") == 0)
        {
            foreach (RawImage image in skins)
            {
                if ("Skin6" == image.name)
                {
                    PlayerPrefs.SetInt("Skin6" + "buy", 1);
                    PlayerPrefs.SetInt("Skin6" + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(GetComponent<RawImage>().name + "buy", 0);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt(GetComponent<RawImage>().name + "buy") == 1)
        {
            buyPanel.color = new Color (0, 0, 0, 0);

            if (PlayerPrefs.GetInt(GetComponent<RawImage>().name + "equip") == 0)
            {
                itemStateText.text = "Equip";
            }
            else if (PlayerPrefs.GetInt(GetComponent<RawImage>().name + "equip") == 1)
            {
                itemStateText.text = "Equipped";
            }
        }
    }

    public void BuyItem()
    {
        if (PlayerPrefs.GetInt(GetComponent<RawImage>().name + "buy") == 0)
        {
            if (Money.money >= price)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - price);
                PlayerPrefs.SetInt(GetComponent<RawImage>().name + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);

                foreach (RawImage image in skins)
                {
                    if (GetComponent<RawImage>().name == image.name)
                    {
                        PlayerPrefs.SetInt(GetComponent<RawImage>().name + "equip", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(image.name + "equip", 0);
                    }
                }
            }
        }
        else if (PlayerPrefs.GetInt(GetComponent<RawImage>().name + "buy") == 1)
        {
            PlayerPrefs.SetInt(GetComponent<RawImage>().name + "equip", 1);
            PlayerPrefs.SetInt("skinNum", skinNum);

            foreach (RawImage image in skins)
            {
                if (GetComponent<RawImage>().name == image.name)
                {
                    PlayerPrefs.SetInt(GetComponent<RawImage>().name + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(image.name + "equip", 0);
                }
            }
        }
    }
}
