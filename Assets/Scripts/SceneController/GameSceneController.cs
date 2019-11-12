using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : SceneControllerBase
{
    HudGame Hud;
    PlayStrategyBase Strategy;

    private void Start()
    {
        Hud = (HudGame)HudBase.Instance;
        Strategy = CreatePlayStrategy();
        Strategy.Start();
    }

    private void Update()
    {
        Strategy.Update();
    }

    private PlayStrategyBase CreatePlayStrategy()
    {
        if (GameInstance.Instance.PlayMode == EnumsHolder.PlayMode.Accelerometer)
        {
            return new AccelerometerPlayStrategy();
        }
        else if (GameInstance.Instance.PlayMode == EnumsHolder.PlayMode.Touchscreen)
        {
            return new TouchscreenPlayStrategy();
        }
        else
        {
            print("PlayMode '" + GameInstance.Instance.PlayMode + "' is not valid");
            return null;
        }
    }
}
