using TMPro;
using UnityEngine;

public class GameHud : HudBase
{
    public TextMeshProUGUI CurrentScore;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI CurrentHealth;

    public GameObject StartLevelWindow;
    public GameObject LoseLevelWindow;
    public GameObject LoseGameWindow;
    public GameObject AccelerometerHowToPlayInfoWindow;
    public GameObject TouchscreenHowToPlayInfoWindow;
    public GameObject CheckpointInfoWindow;
    public GameObject HealthInfoWindow;

    public System.Action OnPause;



    public void OnPauseButton()
    {

        OnPause();
    }



    public UIEventHandler CreateStartLevelWindow()
    {
        return CreateSimpleClickableWindow(StartLevelWindow);
    }

    public UIEventHandler CreateLoseLevelWindow()
    {
        return CreateSimpleClickableWindow(LoseLevelWindow);
    }

    public UIEventHandler CreateLoseGameWindow()
    {
        return CreateSimpleClickableWindow(LoseGameWindow);
    }

    public UIEventHandler CreateHowToPlayInfoWindow()
    { 
        if (GameInstance.Instance.ControllerMode == TypesHolder.ControllerMode.Accelerometer)
            return CreateSimpleClickableWindow(AccelerometerHowToPlayInfoWindow);
        else if (GameInstance.Instance.ControllerMode == TypesHolder.ControllerMode.Touchscreen)
            return CreateSimpleClickableWindow(TouchscreenHowToPlayInfoWindow);
        else
            return null;
    }

    public UIEventHandler CreateCheckpointInfoWindow()
    {
        return CreateSimpleClickableWindow(CheckpointInfoWindow);
    }

    public UIEventHandler CreateHealthInfoWindow()
    {
        return CreateSimpleClickableWindow(HealthInfoWindow);
    }



    private UIEventHandler CreateSimpleClickableWindow(GameObject window)
    {
        GameObject obj = InstantiateUIPrefab(window);
        UIEventHandler Event = obj.GetComponent<UIEventHandler>();

        if (Event == null)
        {
            print("Can't get UIEventHandler component from '" + window + "'");
            return null;
        }

        Event.OnClick += () => Destroy(obj);
        return Event;
    }
}