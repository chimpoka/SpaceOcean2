public class State
{
    private GameHud Hud = (GameHud)HudBase.Instance;
    private int currentScore = 0;
    private int bestScore = 0;
    private int currentHealth = Config.Instance.MaxHealth;
    private int currentCheckpointScore = 0;

    public State()
    {

    }

    public State(StateData data)
    {
        CurrentScore = data.CurrentScore;
        BestScore = data.BestScore;
        CurrentHealth = data.CurrentHealth;
        CurrentCheckpointScore = data.CurrentCheckpointScore;
    }



    public int CurrentScore
    {
        get { return currentScore; }
        set
        {
            currentScore = value;
            Hud?.CurrentScore?.SetText(currentScore.ToString());
        }
    }

    public int BestScore
    {
        get { return bestScore; }
        set
        {
            bestScore = value;
            Hud?.BestScore?.SetText(bestScore.ToString());
        }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            Hud?.CurrentHealth?.SetText(currentHealth.ToString());
        }
    }

    public int CurrentCheckpointScore { get => currentCheckpointScore; set => currentCheckpointScore = value; }
}