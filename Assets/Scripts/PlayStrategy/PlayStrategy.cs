using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStrategy
{
    public int CurrentScore;
    public int BestScore;
    public int CurrentHealth;
    public int MaxHealth;
    public RocketController RocketController;

    public PlayStrategy() : base()
    {
        RocketController = CreateRocketController();
    }

    virtual public void Update()
    {
        RocketController.Update(Time.deltaTime);
    }

    private RocketController CreateRocketController()
    {
        EnumsHolder.ControllerMode mode = GameInstance.Instance.ControllerMode;

        if (mode == EnumsHolder.ControllerMode.Accelerometer)
        {
            return new AccelerometerRocketController();
        }
        else if (mode == EnumsHolder.ControllerMode.Touchscreen)
        {
            return new TouchscreenRocketController();
        }
        else
        {
            MonoBehaviour.print("ControllerMode '" + mode + "' is not valid");
            return null;
        }
    }
}
