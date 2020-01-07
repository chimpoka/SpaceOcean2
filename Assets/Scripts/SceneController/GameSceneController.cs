public class GameSceneController : SceneControllerBase
{
    private HudGame Hud;
    private PlayStrategy Strategy;

    private void Start()
    {
        Hud = (HudGame)HudBase.Instance;
        Strategy = CreateStrategy();
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
}