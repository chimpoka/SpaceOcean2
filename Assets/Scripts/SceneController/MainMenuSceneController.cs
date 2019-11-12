using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneController : SceneControllerBase
{
    HudMainMenu Hud;

    private void Start()
    {
        Hud = (HudMainMenu)HudBase.Instance;
    }

    private void Update()
    {
        
    }
}
