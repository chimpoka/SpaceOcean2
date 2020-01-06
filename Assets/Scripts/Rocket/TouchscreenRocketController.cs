using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchscreenRocketController : RocketController
{
    public override void Update(float deltaTime)
    {
        if (IsPaused)
            return;

        if (Input.GetMouseButton(0))
        {
            SetPitchSmooth(MaxAngle);
        }
        else
        {
            SetPitchSmooth(-MaxAngle);
        }

        base.Update(deltaTime);
    }
}
