using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenuWindow : MonoBehaviour
{
    public delegate void OnToggleDelegate(bool Value);

    public System.Action OnPlayAccelerometer;
    public System.Action OnPlayTouchscreen;
    public System.Action OnBack;
    public OnToggleDelegate OnTutorial;


    public void OnPlayAccelerometerButton()
    {
        OnPlayAccelerometer();
    }

    public void OnPlayTouchscreenButton()
    {
        OnPlayTouchscreen();
    }

    public void OnBackButton()
    {
        OnBack();
    }

    public void OnTutorialToggle(bool value)
    {
        OnTutorial(value); 
    }

    public void SetTutorialToggle(bool value)
    {
        GetComponentInChildren<Toggle>().isOn = value;
    }
}
