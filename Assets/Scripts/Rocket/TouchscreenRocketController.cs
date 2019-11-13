using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchscreenRocketController : RocketController
{
    private float MaxAngle = 45.0f;
    public override void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RotatePitch(MaxAngle);
        }
        else
        {
            RotatePitch(-MaxAngle);
        }
    }
}
