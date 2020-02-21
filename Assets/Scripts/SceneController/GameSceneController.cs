using UnityEngine;

public class GameSceneController : SceneControllerBase
{
    private PlayStrategy Strategy;
    private GameHud Hud;



    private void Start()
    {
        Strategy = CreateStrategy(CreateRocketController());
        Strategy.StartLevel();

        Hud = (GameHud)HudBase.Instance;
        Hud.OnPause += Pause;
    }

    private void Update()
    {
        Strategy.Update();
    }



    private void Pause()
    {
        Strategy.Pause();
        OpenPauseMenuWindow();
    }

    private void Resume()
    {
        Strategy.Resume();
    }

    private void NewGame()
    {
        Strategy.StartNewGame();
    }

    private void OpenOptions()
    {
        OpenOptionsWindow();
    }

    private void OpenMainMenu()
    {
        LevelLoader LevelLoader = new LevelLoader();
        LevelLoader.LoadLevel(0);
    }

    private void Quit()
    {
        Application.Quit();
    }



    void OpenPauseMenuWindow()
    {
        PauseMenuWindow window = Hud.CreatePauseMenuWindow();
        window.OnResume += Resume;
        window.OnNewGame += NewGame;
        window.OnOptions += OpenOptions;
        window.OnMainMenu += OpenMainMenu;
        window.OnQuit += Quit;
    }

    private void OpenOptionsWindow()
    {
        OptionsMenuWindow OptionsMenuWindow = Hud.CreateOptionsMenuWindow();
        OptionsMenuWindow.OnBack += OpenPauseMenuWindow;
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