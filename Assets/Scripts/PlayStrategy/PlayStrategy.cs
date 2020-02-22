public class PlayStrategy
{
    public State State;
    public RocketController RocketController;

    protected GameHud Hud;
    protected Config Config;

    private CheckpointsManager CheckpointsManager;
    private FollowCamera Camera;
    private bool RocketMovementState;

    public PlayStrategy(RocketController rocketController)
    {
        RocketController = rocketController;
        RocketController.OnRocketDied += EndLevel;

        Camera = new FollowCamera(RocketController.Rocket.gameObject);
        Config = Config.Instance;

        Hud = (GameHud)HudBase.Instance;

        CheckpointsManager = new CheckpointsManager();
        CheckpointsManager.OnCheckpointActivated += UpdateCheckpointScore;
        CheckpointsManager.GenerateCheckpoints(Config.CheckpointsCount, Config.StartCheckpointScore, Config.CheckpointsInterval);

        State = SaveSystem.LoadState();
    }



    virtual protected void OnStartLevel()
    {
        Hud.CreateStartLevelWindow().OnClick += () => { RocketController.Paused = false; } ;
    }

    virtual protected void OnLoseLevel()
    {
        Hud.CreateLoseLevelWindow().OnClick += StartLevel;
    }

    virtual protected void OnLoseGame()
    {
        Hud.CreateLoseGameWindow().OnClick += StartNewGame;
    }

    virtual protected void OnCheckpoint()
    {
        
    }



    public void Update()
    {
        RocketController.Update();
        Camera.Update();
        UpdateScore((int)RocketController.GetPosition().x);
    }

    public void StartLevel()
    {
        ResetRocketToLastCheckpoint();
        OnStartLevel();
    }

    private void ResetRocketToLastCheckpoint()
    {
        RocketController.Paused = true;
        RocketController.SetPosition(State.CurrentCheckpointScore, 0, 0);
        RocketController.SetPitch(0);
        RocketController.SetSpeed(Config.StartSpeed);
    }

    public void StartNewGame()
    {
        State.CurrentCheckpointScore = 0;
        State.CurrentHealth = Config.MaxHealth;
        CheckpointsManager.ActivateAllCheckpoins(false);

        StartLevel();
    }

    protected void EndLevel()
    {
        RocketController.Paused = true;
        State.CurrentHealth--;

        if (State.CurrentHealth > 0)
            OnLoseLevel();
        else
            OnLoseGame();

        SaveSystem.SaveState(State);
    }

    private void UpdateCheckpointScore(Checkpoint checkpoint)
    {
        State.CurrentCheckpointScore = State.CurrentScore;
        OnCheckpoint();
    }

    private void UpdateScore(int score)
    {
        State.CurrentScore = score;

        if (State.BestScore < State.CurrentScore)
            State.BestScore = State.CurrentScore;
    }

    public void Pause()
    {
        RocketMovementState = RocketController.Paused;
        RocketController.Paused = true;
    }

    public void Resume()
    {
        RocketController.Paused = RocketMovementState;
    }
}