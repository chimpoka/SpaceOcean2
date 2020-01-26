﻿using TMPro;
using UnityEngine;

public class MainMenuHud : HudBase
{
    public MainMenuWindow MainMenuWindow;
    public PlayMenuWindow PlayMenuWindow;
    public OptionsMenuWindow OptionsMenuWindow;



    public MainMenuWindow CreateMainMenuWindow()
    {
        MainMenuWindow window = Instantiate(MainMenuWindow, transform);
        window.OnOptions += () => Destroy(window.gameObject);
        window.OnPlay += () => Destroy(window.gameObject);

        return window;
    }

    public PlayMenuWindow CreatePlayMenuWindow()
    {
        PlayMenuWindow window = Instantiate(PlayMenuWindow, transform);
        window.OnBack += () => Destroy(window.gameObject);

        return window;
    }

    public OptionsMenuWindow CreateOptionsMenuWindow()
    {
        OptionsMenuWindow window = Instantiate(OptionsMenuWindow, transform);
        window.OnBack += () => Destroy(window.gameObject);

        return window;
    }
}