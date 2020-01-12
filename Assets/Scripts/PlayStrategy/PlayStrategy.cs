﻿public class PlayStrategy
{
    public State State;
    public RocketController RocketController;

    private FollowCamera Camera;
    protected HudGame Hud;
    protected Config Config;

    public PlayStrategy(RocketController rocketController)
    {
        RocketController = rocketController;
        RocketController.OnRocketDied += EndLevel;

        Camera = new FollowCamera(RocketController.Rocket.gameObject);
        Hud = (HudGame)HudBase.Instance;
        Config = Config.Instance;

        State = new State();
        //  State = Data.LoadState();
        State.CurrentHealth = Config.MaxHealth;

        StartLevel();
    }

    virtual public void Update()
    {
        RocketController.Update();
        Camera.Update();
        SetScore( (int)RocketController.GetPosition().x );
    }

    virtual public void LoseLevel()
    {
        Hud.OnLoseLevelWindowClosed = StartLevel;
        Hud.CreateLoseLevelWindow();
    }

    virtual public void LoseGame()
    {
        Hud.OnLoseGameWindowClosed = StartLevel;
        Hud.CreateLoseGameWindow();
    }

    virtual public void StartLevel()
    {
        if (State.CurrentHealth <= 0)
            State.CurrentHealth = Config.MaxHealth;

        RocketController.IsPaused = true;
        RocketController.SetPosition(0, 0, 0);
        RocketController.SetPitch(0);
        Hud.OnStartLevelWindowClosed = OnStartLevelWindowClosed;
        Hud.CreateStartLevelWindow();
    }

    public void Pause()
    {

    }

    public void Resume()
    {

    }



    private void EndLevel()
    {
        RocketController.IsPaused = true;
        State.CurrentHealth--;

        if (State.CurrentHealth > 0)
            LoseLevel();
        else
            LoseGame();
    }

    private void OnStartLevelWindowClosed()
    {
        RocketController.IsPaused = false;
        RocketController.Move(Config.StartSpeed);
    }

    private void SetScore(int score)
    {
        State.CurrentScore = score;

        if (State.BestScore < State.CurrentScore)
            State.BestScore = State.CurrentScore;
    }
}