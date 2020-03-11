public class TutorialPlayStrategy : PlayStrategy
{
    private bool HowToPlayTutorialCompleted = false;
    private bool CheckpointTutorialCompleted = false;
    private bool HealthTutorialCompleted = false;

    public TutorialPlayStrategy(RocketController rocketController) : base(rocketController)
    { }



    override protected void OnStartLevel()
    {
        if (HowToPlayTutorialCompleted)
        {
            base.OnStartLevel();
        }
        else
        {
            Hud.CreateHowToPlayInfoWindow().OnClick += base.OnStartLevel;
            HowToPlayTutorialCompleted = true;
        }
    }

    override protected void OnCheckpoint()
    {
        if (CheckpointTutorialCompleted)
        {
            base.OnCheckpoint();
        }
        else
        {
            Pause();
            UIEventHandler Event = Hud.CreateCheckpointInfoWindow();
            Event.OnClick += base.OnCheckpoint;
            Event.OnClick += Resume;
            CheckpointTutorialCompleted = true;
        }
    }

    override protected void OnLoseLevel()
    {
        if (HealthTutorialCompleted)
        {
            base.OnLoseLevel();
        }
        else
        {
            Hud.CreateHealthInfoWindow().OnClick += base.OnLoseLevel;
            HealthTutorialCompleted = true;
        }
    }
}