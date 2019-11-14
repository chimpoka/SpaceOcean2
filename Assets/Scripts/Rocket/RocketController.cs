using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController
{
    public Rocket Rocket;
    protected float MaxAngle = 45.0f;

    private bool IsMoving;
    private float MoveSpeed;
    private float CurrentPitchAngle;
    private float DesiredPitchAngle;
    private float CurrentRollAngle;
    private float DesiredRollAngle;
    private float PitchLerpAlpha = 0.05f;
    private float RollLerpAlpha = 0.05f;
   

    public RocketController()
    {
        //Rocket = MonoBehaviour.Instantiate
    }

    virtual public void Update(float deltaTime)
    {
        if (IsMoving)
        {
            MoveInternal(deltaTime);
        }

        RotatePitchInternal(deltaTime);
        RotateRollInternal(deltaTime);
    }



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

    public void RotatePitch(float desiredAngle)
    {
        if (CurrentPitchAngle != DesiredPitchAngle)
            DesiredPitchAngle = desiredAngle;
    }

    public void RotateRoll(float desiredAngle)
    {
        if (CurrentRollAngle != DesiredRollAngle)
            DesiredRollAngle = desiredAngle;
    }

   

    private void MoveInternal(float deltaTime)
    {
        Rocket.MoveForward(MoveSpeed * deltaTime);
    }

    private void RotatePitchInternal(float deltaTime)
    {
        if (CurrentPitchAngle != DesiredPitchAngle)
            Mathf.Lerp(CurrentPitchAngle, DesiredPitchAngle, PitchLerpAlpha * deltaTime);
    }

    private void RotateRollInternal(float deltaTime)
    {
        if (CurrentRollAngle != DesiredRollAngle)
            Mathf.Lerp(CurrentRollAngle, DesiredRollAngle, RollLerpAlpha * deltaTime);
    }
}
