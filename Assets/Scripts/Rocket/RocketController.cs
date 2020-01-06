using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController
{
    public Rocket Rocket;
    public bool IsPaused;

    protected float MaxAngle = 45.0f;

    private float MoveSpeed;
    private float DesiredPitchAngle;
    private float DesiredRollAngle;
    private float PitchLerpSpeed = 5.0f;
    private float RollLerpSpeed = 5.0f;
   

    public RocketController()
    {
        GameObject RocketObject = MonoBehaviour.Instantiate(Resources.Load("Rocket"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        Rocket = RocketObject.GetComponent<Rocket>();
    }

    virtual public void Update(float deltaTime)
    {
        if (IsPaused)
            return;

        MoveInternal(deltaTime);
        SetPitchSmoothInternal(deltaTime);
        SetRollSmoothInternal(deltaTime);
    }

    public void Move(float speed)
    {
        MoveSpeed = speed;
    }

    public void StopMove()
    {
        MoveSpeed = 0;
    }

    public void SetPitchSmooth(float desiredAngle)
    {
        DesiredPitchAngle = desiredAngle;
    }

    public void SetRollSmooth(float desiredAngle)
    {
        DesiredRollAngle = desiredAngle;
    }

   

    private void MoveInternal(float deltaTime)
    {
        Rocket.MoveForward(MoveSpeed * deltaTime);
    }

    private void SetPitchSmoothInternal(float deltaTime)
    {
        if (Rocket.GetPitch() != DesiredPitchAngle)
            Rocket.SetPitch(Mathf.Lerp(Rocket.GetPitch(), DesiredPitchAngle, PitchLerpSpeed * deltaTime));
    }

    private void SetRollSmoothInternal(float deltaTime)
    {
        if (Rocket.GetRoll() != DesiredRollAngle)
            Rocket.SetRoll(Mathf.Lerp(Rocket.GetRoll(), DesiredRollAngle, RollLerpSpeed * deltaTime));
    }
}
