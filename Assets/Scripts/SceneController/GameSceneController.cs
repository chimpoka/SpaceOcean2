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
        Hud.OnPauseOpened += Pause;
        Hud.OnPauseClosed += Resume;
    }

    private void Update()
    {
        Strategy.Update();
    }



    private void Pause()
    {
        OpenPauseMenu();
        Strategy.Pause();
    }

    private void Resume()
    {
        Strategy.Resume();
    }

    private void NewGame()
    {
        Hud.CloseCurrentWindows();
        Strategy.StartNewGame();
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



    private void OpenPauseMenu()
    {
        PauseMenu window = Hud.CreatePauseMenu();
        window.PauseMenuWindow.OnResume += Resume;
        window.PauseMenuWindow.OnNewGame += NewGame;
        window.PauseMenuWindow.OnMainMenu += OpenMainMenu;
        window.PauseMenuWindow.OnQuit += Quit;
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