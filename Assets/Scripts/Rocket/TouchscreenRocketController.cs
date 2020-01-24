using UnityEngine;

public class TouchscreenRocketController : RocketController
{
    public override void Update()
    {
        if (Paused)
            return;

        if (Input.GetMouseButton(0))
        {
            SetPitchSmooth(MaxAngle);
        }
        else
        {
            SetPitchSmooth(-MaxAngle);
        }

        base.Update();
    }
}