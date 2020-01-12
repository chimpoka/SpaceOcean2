public class State
{
    private HudGame Hud;

    private int currentScore;
    private int bestScore;
    private int currentHealth;
    //private Checkpoint currentCheckpoint;

    public State()
    {
        Hud = (HudGame)HudBase.Instance;
    }
    
    public int CurrentScore
    {
        get { return currentScore; }
        set
        {
            currentScore = value;
            Hud.CurrentScore.SetText(currentScore.ToString());
        }
    }

    public int BestScore
    {
        get { return bestScore; }
        set
        {
            bestScore = value;
            Hud.BestScore.SetText(bestScore.ToString());
        }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            Hud.CurrentHealth.SetText(currentHealth.ToString());
        }
    }
}