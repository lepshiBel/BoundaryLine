using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    [SerializeField] private TextMeshProUGUI playerScore;
    [SerializeField] private TextMeshProUGUI enemyScore;

    private int pScore;
    private int eScore;
    private SkinControl skinControl;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("pScore"))
        {
            pScore = PlayerPrefs.GetInt("pScore");
        }
        if (PlayerPrefs.HasKey("eScore"))
        {
            eScore = PlayerPrefs.GetInt("eScore");
        }
        if (PlayerPrefs.GetInt("Skin6" + "buy") == 0)
        {
            foreach (RawImage image in skinControl.skins)
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

        playerScore.text = pScore.ToString();
        enemyScore.text = eScore.ToString();
    }

    public void WinRound(string player)
    {
        if (player == "player")
        {
            pScore++;
            Money.money++;

            SaveScore();

            playerScore.text = pScore.ToString();
        }
        else if (player == "enemy")
        {
            eScore++;

            SaveScore();

            enemyScore.text = eScore.ToString();
        }

        ball.SetActive(false);
        Invoke("RestartGame", 1.5f);
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("pScore", pScore);
        PlayerPrefs.SetInt("eScore", eScore);
        PlayerPrefs.SetInt("money", Money.money);
        PlayerPrefs.Save();
    }

    private void RestartGame()
    {
        if (pScore >= 5 || eScore >= 5)
        {
            PlayerPrefs.DeleteKey("pScore");
            PlayerPrefs.DeleteKey("eScore");
        }

        SceneManager.LoadScene("Game");
    }
}