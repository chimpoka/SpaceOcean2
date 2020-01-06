using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerRocketController : RocketController
{
    private float RotationPower = 3.0f;

    public override void Update(float deltaTime)
    {
        if (IsPaused)
            return;

        SetPitchSmooth(Mathf.Clamp(GetDeviceAngle() * RotationPower, -MaxAngle,  MaxAngle));

        base.Update(deltaTime);
    }



    private float GetDeviceAngle()
    {
        return Mathf.Atan2(Input.acceleration.x, -Input.acceleration.y) * Mathf.Rad2Deg * -1;
    }
}