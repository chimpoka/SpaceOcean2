public class GameSceneController : SceneControllerBase
{
    private PlayStrategy Strategy;

    private void Start()
    {
        Strategy = CreateStrategy(CreateRocketController());
        Strategy.StartLevel();
    }

    private void Update()
    {
        Strategy.Update();
    }

    private PlayStrategy CreateStrategy(RocketController rocketController)
    {
        TypesHolder.PlayMode playMode = GameInstance.Instance.PlayMode;

        if (playMode == TypesHolder.PlayMode.Normal)
        {
            return new PlayStrategy(rocketController);
        }
        else if (playMode == TypesHolder.PlayMode.Tutorial)
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
        TypesHolder.ControllerMode mode = GameInstance.Instance.ControllerMode;

        if (mode == TypesHolder.ControllerMode.Accelerometer)
        {
            return new AccelerometerRocketController();
        }
        else if (mode == TypesHolder.ControllerMode.Touchscreen)
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