[System.Serializable]
public class StateData
{
    public int CurrentScore;
    public int BestScore;
    public int CurrentHealth;
    public int CurrentCheckpointScore;

    public StateData(State state)
    {
        CurrentScore = state.CurrentScore;
        BestScore = state.BestScore;
        CurrentHealth = state.CurrentHealth;
        CurrentCheckpointScore = state.CurrentCheckpointScore;
    }
}