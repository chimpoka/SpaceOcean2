using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWindow : MonoBehaviour
{
    public System.Action OnPlay;
    public System.Action OnOptions;
    public System.Action OnQuit;

    public void OnPlayButton()
    {
        OnPlay();
    }

    public void OnOptionsButton()
    {
        OnOptions();
    }

    public void OnQuitButton()
    {
        OnQuit();
    }
}
