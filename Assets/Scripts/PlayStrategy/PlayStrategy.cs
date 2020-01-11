using UnityEngine;

public class PlayStrategy
{
    public int CurrentScore;
    public int BestScore;
    public int CurrentHealth;
    public int MaxHealth;
    public RocketController RocketController;

    private FollowCamera Camera;
    private IntegerTimer Timer;
    protected HudGame Hud;
    protected Config Config;

    public PlayStrategy()
    {
        RocketController = CreateRocketController();
        RocketController.OnRocketDied += LoseLevel;

        Camera = new FollowCamera(RocketController.Rocket.gameObject);
        Hud = (HudGame)HudBase.Instance;
        Config = Config.Instance;

        StartLevel();
    }

    virtual public void Update()
    {
        RocketController.Update();
        Camera.Update();
    }

    virtual public void LoseLevel()
    {
        RocketController.IsPaused = true;
        Hud.CreateLoseLevelImage();
        Hud.OnLoseLevelImageClosed += OnLoseLevelImageClosed;
    }

    virtual public void LoseGame()
    {

    }

    virtual public void StartLevel()
    {
        RocketController.IsPaused = true;
        RocketController.SetPosition(0, 0, 0);
        RocketController.SetPitch(0);
        Hud.CreateStartLevelImage();
        Hud.OnStartLevelImageClosed += OnStartLevelImageClosed;
    }

    public void Pause()
    {

    }

    public void Resume()
    {

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
            MonoBehaviour.print("ControllerMode '" + mode + "' is not valid");
            return null;
        }
    }

    private void OnStartLevelImageClosed()
    {
        RocketController.IsPaused = false;
        RocketController.Move(Config.StartSpeed);
        Hud.OnStartLevelImageClosed -= OnStartLevelImageClosed;
    }

    private void OnLoseLevelImageClosed()
    {
        StartLevel();
        Hud.OnLoseLevelImageClosed -= OnLoseLevelImageClosed;
    }
}