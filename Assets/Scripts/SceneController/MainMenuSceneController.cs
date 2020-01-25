using UnityEngine;

public class MainMenuSceneController : SceneControllerBase
{
    MainMenuHud Hud;

    private void Start()
    {
        // Bug, check this later
        GameInstance GI = GameInstance.Instance;
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

    }

    private void OnQuit()
    {
        Application.Quit();
    }



    private void OnPlayAccelerometer()
    {
        LevelLoader levelLoader = new LevelLoader();
        levelLoader.LoadLevel(1);
    }

    private void OnPlayTouchscreen()
    {
        LevelLoader levelLoader = new LevelLoader();
        levelLoader.LoadLevel(1);
    }

    private void OnBackPlayMenu()
    {
        OpenMainMenuWindow();
    }

    private void OnTutorial(bool value)
    {
        GameInstance.Instance.PlayTutorial = value;
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
    }

    private void CreateOptionsWindow()
    {
        //MainMenuWindow MainMenuWindow = Hud.CreateMainMenuWindow();
        //MainMenuWindow.OnPlay += OnPlay;
        //MainMenuWindow.OnOptions += OnOptions;
        //MainMenuWindow.OnQuit += OnQuit;
    }
}