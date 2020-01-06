using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : SceneControllerBase
{
    HudGame Hud;
    PlayStrategy Strategy;

    private void Start()
    {
        Hud = (HudGame)HudBase.Instance;
        Strategy = CreateStrategy();
        Strategy.RocketController.Rocket.OnDied += LoseLevel;
    }

    private void Update()
    {
        Strategy.Update();
    }

    private PlayStrategy CreateStrategy()
    {
        EnumsHolder.PlayMode playMode = GameInstance.Instance.PlayMode;

        if (playMode == EnumsHolder.PlayMode.Normal)
        {
            return new PlayStrategy();
        }
        else if (playMode == EnumsHolder.PlayMode.Tutorial)
        {
            return new TutorialPlayStrategy();
        }
        else
        {
            print("PlayMode '" + playMode + "' is not valid");
            return null;
        }
    }

    public void Pause()
    {

    }

    public void Resume()
    {

    }

    public void LoseLevel()
    {

    }

    public void LoseGame()
    {

    }
}
