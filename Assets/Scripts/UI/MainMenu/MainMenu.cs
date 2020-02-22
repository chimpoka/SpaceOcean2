using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public MainMenuWindow MainMenuWindow;
    public PlayMenuWindow PlayMenuWindow;
    public OptionsMenuWindow OptionsMenuWindow;

    private void Start()
    {
        OpenMainWindow();

        MainMenuWindow.OnPlay += OpenPlayWindow;
        MainMenuWindow.OnOptions += OpenOptionsWindow;
        PlayMenuWindow.OnBack += OpenMainWindow;
        OptionsMenuWindow.OnBack += OpenMainWindow;
    }



    private void OpenMainWindow()
    {
        MainMenuWindow.gameObject.SetActive(true);
        PlayMenuWindow.gameObject.SetActive(false);
        OptionsMenuWindow.gameObject.SetActive(false);
    }

    private void OpenPlayWindow()
    {
        MainMenuWindow.gameObject.SetActive(false);
        PlayMenuWindow.gameObject.SetActive(true);
        OptionsMenuWindow.gameObject.SetActive(false);
    }

    private void OpenOptionsWindow()
    {
        MainMenuWindow.gameObject.SetActive(false);
        PlayMenuWindow.gameObject.SetActive(false);
        OptionsMenuWindow.gameObject.SetActive(true);
    }
}
