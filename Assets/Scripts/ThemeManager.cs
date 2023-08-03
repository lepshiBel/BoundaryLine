#nullable enable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Theme
{
    Dark,
    Light 
}

public class ThemeManager : MonoBehaviour
{
    public static Theme CurrentTheme { get; private set; } = Theme.Dark;

    private const string ThemeKey = "SelectedTheme";

    public MainMenuObjectsContainer? mainMenuContainer;
    public GamemodeObjectsContainer? gamemodeContainer;
    public GameObjectsContainer? gameContainer;
    public PauseMenuObjectsContainer? pauseMenuContainer;
    public OptionsObjectsContainer? optionsContainer;
    public ShopObjectsContainer? shopContainer;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(ThemeKey))
        {
            int themeValue = PlayerPrefs.GetInt(ThemeKey);
            CurrentTheme = (Theme)themeValue;
        }
        else
        {
            PlayerPrefs.SetInt(ThemeKey, (int)CurrentTheme);
        }

        if (PlayerPrefs.GetInt(ThemeKey) == 0)
        {
            ApplyMainMenuTheme(new Color32(0x9C, 0x2C, 0x53, 0xFF), new Color32(0x9C, 0x2C, 0x53, 0xFF), new Color32(0x9C, 0x2C, 0x53, 0xFF));
            ApplyGamemodeTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white, Color.white, Color.white);
            
            ApplyGameTheme(Color.white, Color.white, Color.white, Color.white);        

            ApplyPauseTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white, Color.white);
            ApplyOptionsTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white);
            ApplyShopTheme("dark", new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, new Color32(0x72, 0x72, 0x72, 0xFF), Color.white);
        }
        else if (PlayerPrefs.GetInt(ThemeKey) == 1)
        {
            ApplyMainMenuTheme(Color.white, Color.white, Color.white);
            ApplyGamemodeTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF));

            if (PlayerPrefs.GetInt("mapSkinNum") == 1)
            {
                ApplyGameTheme(Color.black, new Color32(0x00, 0x00, 0x00, 0x82), Color.black, Color.black);
            }

            ApplyPauseTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white);
            ApplyOptionsTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), new Color32(0x2E, 0x2E, 0x2E, 0xFF));
            ApplyShopTheme("light", Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), new Color32(0xD1, 0xD1, 0xD1, 0xFF), new Color32(0x2E, 0x2E, 0x2E, 0xFF));
        }
    }

    public void SetTheme(int theme)
    {
        CurrentTheme = (Theme)theme;
        PlayerPrefs.SetInt(ThemeKey, theme);

        if (PlayerPrefs.GetInt(ThemeKey) == 0)
        {
            PlayerPrefs.SetInt("mapSkinNum", 0);

            ApplyMainMenuTheme(new Color32(0x9C, 0x2C, 0x53, 0xFF), new Color32(0x9C, 0x2C, 0x53, 0xFF), new Color32(0x9C, 0x2C, 0x53, 0xFF));
            ApplyGamemodeTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white, Color.white, Color.white);

            ApplyGameTheme(Color.white, Color.white, Color.white, Color.white);

            ApplyPauseTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white, Color.white);
            ApplyOptionsTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white);
            ApplyShopTheme("dark", new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, new Color32(0x72, 0x72, 0x72, 0xFF), Color.white);    
        }
        else if (PlayerPrefs.GetInt(ThemeKey) == 1)
        {
            PlayerPrefs.SetInt("mapSkinNum", 1);

            ApplyMainMenuTheme(Color.white, Color.white, Color.white);
            ApplyGamemodeTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF));

            if (PlayerPrefs.GetInt("mapSkinNum") == 1)
            {
                ApplyGameTheme(Color.black, new Color32(0x00, 0x00, 0x00, 0x82), Color.black, Color.black);
            }

            ApplyPauseTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white);
            ApplyOptionsTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), new Color32(0x2E, 0x2E, 0x2E, 0xFF));
            ApplyShopTheme("light", Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), new Color32(0xD1, 0xD1, 0xD1, 0xFF), new Color32(0x2E, 0x2E, 0x2E, 0xFF));
        }
    }

    private void ApplyMainMenuTheme(Color lineColor, Color buttonsColor, Color textsColor)
    {
        if (mainMenuContainer != null)
        {
            if (PlayerPrefs.GetInt(ThemeKey) == 0)
            {
                mainMenuContainer.panel.SetActive(true);
                mainMenuContainer.darkBackground.SetActive(true);
                mainMenuContainer.lightBackground.SetActive(false);
            }
            else if (PlayerPrefs.GetInt(ThemeKey) == 1)
            {
                mainMenuContainer.panel.SetActive(false);
                mainMenuContainer.darkBackground.SetActive(false);
                mainMenuContainer.lightBackground.SetActive(true);
            }

            mainMenuContainer.line.color = lineColor;

            foreach (var button in mainMenuContainer.buttons)
            {
                button.color = buttonsColor;
            }

            foreach (var text in mainMenuContainer.texts)
            {
                text.color = textsColor;
            }
        }
    }

    private void ApplyGamemodeTheme(Color backgroundColor, Color titleColor, Color buttonsColor, Color buttonTextsColor, Color iconColor)
    {
        if (gamemodeContainer != null)
        {
            gamemodeContainer.background.color = backgroundColor;

            gamemodeContainer.title.color = titleColor;

            foreach (var button in gamemodeContainer.buttons)
            {
                button.color = buttonsColor;
            }

            foreach (var text in gamemodeContainer.buttonTexts)
            {
                text.color = buttonTextsColor;
            }

            gamemodeContainer.icon.color = iconColor;
        }
    }

    private void ApplyGameTheme(Color pauseColor, Color scoresColor, Color platformColor, Color ballColor)
    {
        if (gameContainer != null)
        {
            gameContainer.pause.color = pauseColor;

            foreach (var score in gameContainer.scores)
            {
                score.color = scoresColor;
            }

            foreach (var platform in gameContainer.platforms)
            {
                platform.GetComponent<Renderer>().material.color = platformColor;
            }

            gameContainer.ball.GetComponent<Renderer>().material.color = ballColor;
        }
    }

    private void ApplyPauseTheme(Color backgroundColor, Color titleColor, Color buttonsColor, Color buttonTextsColor)
    {
        if (pauseMenuContainer != null)
        {
            pauseMenuContainer.background.color = backgroundColor;

            pauseMenuContainer.title.color = titleColor;

            foreach (var button in pauseMenuContainer.buttons)
            {
                button.color = buttonsColor;
            }

            foreach (var text in pauseMenuContainer.buttonTexts)
            {
                text.color = buttonTextsColor;
            }
        }
    }

    private void ApplyOptionsTheme(Color backgroundColor, Color textsColor, Color iconsColor)
    {
        if (optionsContainer != null)
        {
            optionsContainer.background.color = backgroundColor;

            foreach (var text in optionsContainer.texts)
            {
                text.color = textsColor;
            }

            foreach (var icon in optionsContainer.icons)
            {
                icon.color = iconsColor;
            }
        }
    }

    private void ApplyShopTheme(string backgroundType, Color backgroundColor, Color textsColor, Color slotsColor, Color iconsColor)
    {
        if (shopContainer != null)
        {
            shopContainer.background.color = backgroundColor;

            foreach (var text in shopContainer.texts)
            {
                text.color = textsColor;
            }

            foreach (var slot in shopContainer.slots)
            {
                slot.color = slotsColor;
            }

            for (int i = 0; i <= shopContainer.skins.Length; i++)
            {
                if (backgroundType == "dark")
                {
                    shopContainer.skins[0].SetActive(true);
                    shopContainer.skins[1].SetActive(false);
                    shopContainer.skins[2].SetActive(true);
                    shopContainer.skins[3].SetActive(false);
                    shopContainer.skins[4].SetActive(true);
                    shopContainer.skins[5].SetActive(false);
                }
                else if (backgroundType == "light")
                {
                    shopContainer.skins[0].SetActive(false);
                    shopContainer.skins[1].SetActive(true);
                    shopContainer.skins[2].SetActive(false);
                    shopContainer.skins[3].SetActive(true);
                    shopContainer.skins[4].SetActive(false);
                    shopContainer.skins[5].SetActive(true);
                }
            }

            foreach (var icon in shopContainer.icons)
            {
                icon.color = iconsColor;
            }
        }
    }
}
