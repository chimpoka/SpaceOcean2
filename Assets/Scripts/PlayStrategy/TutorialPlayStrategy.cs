using UnityEngine;

public class TutorialPlayStrategy : PlayStrategy
{
    private Tutorial Tutorial;

    public TutorialPlayStrategy(RocketController rocketController) : base(rocketController)
    {
        Tutorial = CreateTutorial(GameInstance.Instance.ControllerMode);
        Tutorial.OnHowToPlayInfoWindowClosed += OnCloseHowToPlayInfoWindow;
        Tutorial.OnCheckpointInfoWindowClosed += OnCloseCheckpointInfoWindow;
        Tutorial.OnHealthInfoWindowClosed += OnCloseHealthInfoWindow;
    }

    public override void Update()
    {
        
    }

    private Tutorial CreateTutorial(EnumsHolder.ControllerMode controllerMode)
    {
        if (controllerMode == EnumsHolder.ControllerMode.Accelerometer)
        {
            return new AccelerometerTutorial();
        }
        else if (controllerMode == EnumsHolder.ControllerMode.Touchscreen)
        {
            return new TouchscreenTutorial();
        }
        else
        {
            MonoBehaviour.print("ControllerMode '" + controllerMode + "' is not valid");
            return null;
        }
    }

    private void OnCloseHowToPlayInfoWindow()
    {

    }

    private void OnCloseCheckpointInfoWindow()
    {

    }

    private void OnCloseHealthInfoWindow()
    {

    }
}