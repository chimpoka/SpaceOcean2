using TMPro;
using UnityEngine;

public class MainMenuHud : HudBase
{
    public MainMenu MainMenu;

    public MainMenu CreateMainMenu()
    {
        return Instantiate(MainMenu, transform);
    }
}