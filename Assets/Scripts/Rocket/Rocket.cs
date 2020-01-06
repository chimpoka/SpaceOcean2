using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public event Action OnDied; 

    public void MoveForward(float units)
    {
        transform.Translate(new Vector3(units, 0, 0), Space.Self);
    }

    public float GetPitch()
    {
        float angle = transform.eulerAngles.z;
        if (angle > 180)
            angle -= 360;

        return angle;
    }

    public void SetPitch(float angle)
    {
        if (angle < 0)
            angle += 360;

        Vector3 lastEuler = transform.eulerAngles;
        transform.eulerAngles = new Vector3(lastEuler.x, lastEuler.y, angle);
    }

    public float GetRoll()
    {
        return 0;
    }

    public void SetRoll(float angle)
    {

    }

    public void Die()
    {

    }
}
