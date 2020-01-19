public class PlayStrategy
{
    public State State;
    public RocketController RocketController;

    protected HudGame Hud;
    protected Config Config;

    private CheckpointsManager CheckpointsManager;
    private FollowCamera Camera;

    public PlayStrategy(RocketController rocketController)
    {
        RocketController = rocketController;
        RocketController.OnRocketDied += EndLevel;

        Camera = new FollowCamera(RocketController.Rocket.gameObject);
        Hud = (HudGame)HudBase.Instance;
        Config = Config.Instance;

        CheckpointsManager = new CheckpointsManager();
        CheckpointsManager.OnCheckpointActivated += OnCheckpoint;
        CheckpointsManager.GenerateCheckpoints(Config.CheckpointsCount, Config.StartCheckpointScore, Config.CheckpointsInterval);

        State = SaveSystem.LoadState();

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
        RocketController.SetPosition(State.CurrentCheckpointScore, 0, 0);
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
        {
            LoseLevel();
        }
        else
        {
            State.CurrentCheckpointScore = 0;
            CheckpointsManager.ActivateAllCheckpoins(false);
            LoseGame();
        }

        SaveSystem.SaveState(State);
    }

    private void OnCheckpoint(Checkpoint checkpoint)
    {
        State.CurrentCheckpointScore = State.CurrentScore;
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