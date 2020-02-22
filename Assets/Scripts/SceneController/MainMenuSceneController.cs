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
        OpenMainMenu();
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

    private void OnTutorial(bool value)
    {
        GameInstance.Instance.PlayMode = (value == true) ? TypesHolder.PlayMode.Tutorial : TypesHolder.PlayMode.Normal;
    }

    private void OpenMainMenu()
    {
        MainMenu MainMenu = Hud.CreateMainMenu();
        MainMenu.MainMenuWindow.OnQuit += OnQuit;
        MainMenu.PlayMenuWindow.OnPlayAccelerometer += OnPlayAccelerometer;
        MainMenu.PlayMenuWindow.OnPlayTouchscreen += OnPlayTouchscreen;
        MainMenu.PlayMenuWindow.OnTutorial += OnTutorial;
        MainMenu.PlayMenuWindow.SetTutorialToggle(GameInstance.Instance.PlayMode == TypesHolder.PlayMode.Tutorial ? true : false);
    }
}