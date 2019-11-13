using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController
{
    public Rocket Rocket;
    private bool IsMoving;
    private float MoveSpeed;
    private float CurrentPitchAngle;
    private float DesiredPitchAngle;
    private float CurrentRollAngle;
    private float DesiredRollAngle;

    public RocketController()
    {
        //Rocket = MonoBehaviour.Instantiate
    }

    virtual public void Update() { }

    public void Move(float speed)
    {
        MoveSpeed = speed;
        IsMoving = true;
    }

    public void StopMove()
    {
        MoveSpeed = 0;
        IsMoving = false;
    }

    public void RotatePitch(float angle)
    {
        if (CurrentPitchAngle == DesiredPitchAngle)
            return;


    }

    public void RotateRoll(float angle)
    {
        if (CurrentRollAngle == DesiredRollAngle)
            return;


    }
}
