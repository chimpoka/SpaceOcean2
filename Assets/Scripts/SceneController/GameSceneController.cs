public class GameSceneController : SceneControllerBase
{
    private PlayStrategy Strategy;

    private void Start()
    {
        Strategy = CreateStrategy(CreateRocketController());
    }

    private void Update()
    {
        Strategy.Update();
    }

    private PlayStrategy CreateStrategy(RocketController rocketController)
    {
        EnumsHolder.PlayMode playMode = GameInstance.Instance.PlayMode;

        if (playMode == EnumsHolder.PlayMode.Normal)
        {
            return new PlayStrategy(rocketController);
        }
        else if (playMode == EnumsHolder.PlayMode.Tutorial)
        {
            return new TutorialPlayStrategy(rocketController);
        }
        else
        {
            print("PlayMode '" + playMode + "' is not valid");
            return null;
        }
    }

    private RocketController CreateRocketController()
    {
        EnumsHolder.ControllerMode mode = GameInstance.Instance.ControllerMode;

        if (mode == EnumsHolder.ControllerMode.Accelerometer)
        {
            return new AccelerometerRocketController();
        }
        else if (mode == EnumsHolder.ControllerMode.Touchscreen)
        {
            return new TouchscreenRocketController();
        }
        else
        {
            print("ControllerMode '" + mode + "' is not valid");
            return null;
        }
    }
}