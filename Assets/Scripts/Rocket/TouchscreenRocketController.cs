using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchscreenRocketController : RocketController
{
    public override void Update(float deltaTime)
    {
        if (Input.GetMouseButton(0))
        {
            RotatePitch(MaxAngle);
        }
        else
        {
            RotatePitch(-MaxAngle);
        }

        base.Update(deltaTime);
    }
}
