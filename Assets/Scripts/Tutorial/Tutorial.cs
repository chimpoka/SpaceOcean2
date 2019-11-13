using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial
{
    public GameObject HowToPlayInfoWindow;
    public GameObject CheckpointInfoWindow;
    public GameObject HealthInfoWindow;

    public event Action OnHowToPlayInfoWindowClosed;
    public event Action OnCheckpointInfoWindowClosed;
    public event Action OnHealthInfoWindowClosed;

    virtual public void ShowHowToPlayInfoWindow() { }
    virtual public void HideHowToPlayInfoWindow() { OnHowToPlayInfoWindowClosed.Invoke(); }
    virtual public void ShowCheckpointInfoWindow() { }
    virtual public void HideCheckpointInfoWindow() { OnCheckpointInfoWindowClosed.Invoke(); }
    virtual public void ShowHealthInfoWindow() { }
    virtual public void HideHealthInfoWindow() { OnHealthInfoWindowClosed.Invoke(); }
}
