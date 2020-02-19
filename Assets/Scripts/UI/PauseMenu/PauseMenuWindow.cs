using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuWindow : MonoBehaviour
{
    public System.Action OnResume;
    public System.Action OnNewGame;
    public System.Action OnOptions;
    public System.Action OnMainMenu;
    public System.Action OnQuit;

    public void OnResumeButton()
    {
        OnResume();
    }

    public void OnNewGameButton()
    {
        OnNewGame();
    }

    public void OnOptionsButton()
    {
        OnOptions();
    }

    public void OnMainMenuButton()
    {
        OnMainMenu();
    }
    
    public void OnQuitButton()
    {
        OnQuit();
    }
}
