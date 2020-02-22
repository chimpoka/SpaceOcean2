using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public PauseMenuWindow PauseMenuWindow;
    public OptionsMenuWindow OptionsMenuWindow;

    private void Start()
    {
        OpenPauseWindow();

        PauseMenuWindow.OnResume += () => Destroy(gameObject);
        PauseMenuWindow.OnNewGame += () => Destroy(gameObject);
        PauseMenuWindow.OnOptions += OpenOptionsWindow;
        OptionsMenuWindow.OnBack += OpenPauseWindow;
    }

    private void OpenPauseWindow()
    {
        PauseMenuWindow.gameObject.SetActive(true);
        OptionsMenuWindow.gameObject.SetActive(false);
    }

    private void OpenOptionsWindow()
    {
        PauseMenuWindow.gameObject.SetActive(false);
        OptionsMenuWindow.gameObject.SetActive(true);
    }
}
