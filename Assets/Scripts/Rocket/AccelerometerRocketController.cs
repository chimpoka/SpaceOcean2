using UnityEngine;

public class AccelerometerRocketController : RocketController
{
    private float RotationPower = 3.0f;

    public override void Update()
    {
        if (IsPaused)
            return;

        SetPitchSmooth(Mathf.Clamp(GetDeviceAngle() * RotationPower, -MaxAngle,  MaxAngle));

        base.Update();
    }



    private float GetDeviceAngle()
    {
        return Mathf.Atan2(Input.acceleration.x, -Input.acceleration.y) * Mathf.Rad2Deg * -1;
    }
}