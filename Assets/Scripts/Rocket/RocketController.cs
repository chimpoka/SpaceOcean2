using UnityEngine;

public class RocketController
{
    public Rocket Rocket;
    public bool Paused;
    public event System.Action OnRocketDied;

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
        Rocket.OnDied += () => OnRocketDied();
    }

    virtual public void Update()
    {
        if (Paused)
            return;

        MoveInternal(Time.deltaTime);
        SetPitchSmoothInternal(Time.deltaTime);
        SetRollSmoothInternal(Time.deltaTime);
    }

    public void SetSpeed(float speed)
    {
        MoveSpeed = speed;
    }

    public void SetPitchSmooth(float desiredAngle)
    {
        DesiredPitchAngle = desiredAngle;
    }

    public void SetRollSmooth(float desiredAngle)
    {
        DesiredRollAngle = desiredAngle;
    }

    public void SetPosition(float x, float y, float z)
    {
        Rocket.SetPosition(new Vector3(x, y, z));
    }

    public Vector3 GetPosition()
    {
        return Rocket.GetPosition();
    }

    public void SetPitch(float angle)
    {
        Rocket.SetPitch(angle);
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