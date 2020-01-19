using System;

public class MainMenuSceneController : SceneControllerBase
{
    HudMainMenu Hud;

    private void Start()
    {
        // Bug, check this later
        GameInstance GI = GameInstance.Instance;
        Config C = Config.Instance;

        Hud = (HudMainMenu)HudBase.Instance;
        Hud.OnPlay += OnPlay;
    }

    public void OnPlay()
    {
        LevelLoader levelLoader = new LevelLoader();
        levelLoader.LoadLevel(1);
    }

    private void Update()
    {

    }
}