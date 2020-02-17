using UnityEngine;

public class MainMenuSceneController : SceneControllerBase
{
    MainMenuHud Hud;
    GameInstance GameInstance;

    private void Start()
    {
        // Bug, check this later
        GameInstance = GameInstance.Instance;
        Config C = Config.Instance;

        Hud = (MainMenuHud)HudBase.Instance;
        OpenMainMenuWindow();
    }

   

    private void OnPlay()
    {
        OpenPlayMenuWindow();
    }

    private void OnOptions()
    {
        OpenOptionsWindow();
    }

    private void OnQuit()
    {
        Application.Quit();
    }



    private void OnPlayAccelerometer()
    {
        GameInstance.ControllerMode = TypesHolder.ControllerMode.Accelerometer;
        LevelLoader levelLoader = new LevelLoader();
        levelLoader.LoadLevel(1);
    }

    private void OnPlayTouchscreen()
    {
        GameInstance.ControllerMode = TypesHolder.ControllerMode.Touchscreen;
        LevelLoader levelLoader = new LevelLoader();
        levelLoader.LoadLevel(1);
    }

    private void OnBackPlayMenu()
    {
        OpenMainMenuWindow();
    }

    private void OnTutorial(bool value)
    {
        GameInstance.Instance.PlayMode = (value == true) ? TypesHolder.PlayMode.Tutorial : TypesHolder.PlayMode.Normal;
    }



    private void OnBackOptionsMenu()
    {
        OpenMainMenuWindow();
    }



    private void OpenMainMenuWindow()
    {
        MainMenuWindow MainMenuWindow = Hud.CreateMainMenuWindow();
        MainMenuWindow.OnPlay += OnPlay;
        MainMenuWindow.OnOptions += OnOptions;
        MainMenuWindow.OnQuit += OnQuit;
    }

    private void OpenPlayMenuWindow()
    {
        PlayMenuWindow PlayMenuWindow = Hud.CreatePlayMenuWindow();
        PlayMenuWindow.OnPlayAccelerometer += OnPlayAccelerometer;
        PlayMenuWindow.OnPlayTouchscreen += OnPlayTouchscreen;
        PlayMenuWindow.OnBack += OnBackPlayMenu;
        PlayMenuWindow.OnTutorial += OnTutorial;
        PlayMenuWindow.SetTutorialToggle(GameInstance.Instance.PlayMode == TypesHolder.PlayMode.Tutorial ? true : false);
    }

    private void OpenOptionsWindow()
    {
        OptionsMenuWindow OptionsMenuWindow = Hud.CreateOptionsMenuWindow();
        OptionsMenuWindow.OnBack += OnBackPlayMenu;
    }
}