#nullable enable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language
{
    English,
    Russian
}

public class LanguageManager : MonoBehaviour
{
    public static Language CurrentLanguage { get; private set; } = Language.English;

    private const string LanguageKey = "SelectedLanguage";

    public MainMenuObjectsContainer? mainMenuContainer;
    public GamemodeObjectsContainer? gamemodeContainer;
    public PauseMenuObjectsContainer? pauseMenuContainer;
    public OptionsObjectsContainer? optionsContainer;
    public ShopObjectsContainer? shopContainer;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(LanguageKey))
        {
            int languageValue = PlayerPrefs.GetInt(LanguageKey);
            CurrentLanguage = (Language)languageValue;
        }
        else
        {
            PlayerPrefs.SetInt(LanguageKey, (int)CurrentLanguage);
        }

        if (PlayerPrefs.GetInt(LanguageKey) == 0)
        {
            //ApplyMainMenuTheme(new Color32(0x9C, 0x2C, 0x53, 0xFF), new Color32(0x9C, 0x2C, 0x53, 0xFF), new Color32(0x9C, 0x2C, 0x53, 0xFF));
            //ApplyGamemodeTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white, Color.white);
            //ApplyPauseTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white, Color.white);
            //ApplyOptionsTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white);
            //ApplyShopTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, new Color32(0x72, 0x72, 0x72, 0xFF));
        }
        else if (PlayerPrefs.GetInt(LanguageKey) == 1)
        {
            //ApplyMainMenuTheme(Color.white, Color.white, Color.white);
            //ApplyGamemodeTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white);
            //ApplyPauseTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white);
            //ApplyOptionsTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF));
            //ApplyShopTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), new Color32(0xD1, 0xD1, 0xD1, 0xFF));
        }
    }

    public void SetLanguage(int language)
    {
        CurrentLanguage = (Language)language;
        PlayerPrefs.SetInt(LanguageKey, language);

        if (PlayerPrefs.GetInt(LanguageKey) == 0)
        {
            //ApplyMainMenuTheme(new Color32(0x9C, 0x2C, 0x53, 0xFF), new Color32(0x9C, 0x2C, 0x53, 0xFF), new Color32(0x9C, 0x2C, 0x53, 0xFF));
            //ApplyGamemodeTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white, Color.white);
            //ApplyPauseTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white, Color.white);
            //ApplyOptionsTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white);
            //ApplyShopTheme(new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, new Color32(0x72, 0x72, 0x72, 0xFF));
        }
        else if (PlayerPrefs.GetInt(LanguageKey) == 1)
        {
            //ApplyMainMenuTheme(Color.white, Color.white, Color.white);
            //ApplyGamemodeTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white);
            //ApplyPauseTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), Color.white, Color.white);
            //ApplyOptionsTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF));
            //ApplyShopTheme(Color.white, new Color32(0x2E, 0x2E, 0x2E, 0xFF), new Color32(0xD1, 0xD1, 0xD1, 0xFF));
        }
    }

    private void ApplyLanguage()
    {

    }
}