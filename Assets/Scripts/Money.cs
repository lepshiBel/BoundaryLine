using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static int money;
    public TextMeshProUGUI moneyText;

    private void Update()
    {
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }

        moneyText.text = money.ToString();
    }
}
