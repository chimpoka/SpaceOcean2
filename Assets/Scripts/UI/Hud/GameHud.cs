using TMPro;
using UnityEngine;

public class GameHud : HudBase
{
    public TextMeshProUGUI CurrentScore;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI CurrentHealth;

    [SerializeField]
    private GameObject StartLevelWindow;
    [SerializeField]
    private GameObject LoseLevelWindow;
    [SerializeField]
    private GameObject LoseGameWindow;
    [SerializeField]
    private GameObject AccelerometerHowToPlayInfoWindow;
    [SerializeField]
    private GameObject TouchscreenHowToPlayInfoWindow;
    [SerializeField]
    private GameObject CheckpointInfoWindow;
    [SerializeField]
    private GameObject HealthInfoWindow;

    [SerializeField]
    private PauseMenu PauseMenuPrefab;
    [SerializeField]
    private GameObject ActiveWindows;

    public System.Action OnPauseOpened;
    public System.Action OnPauseClosed;

    private PauseMenu PauseMenuRef;



    public void CloseCurrentWindows()
    {
        foreach (Transform child in ActiveWindows.transform)
            Destroy(child.gameObject);
    }

    public PauseMenu CreatePauseMenu()
    {
        PauseMenu window = Instantiate(PauseMenuPrefab, ActiveWindows.transform);
        PauseMenuRef = window;
        OnPauseClosed += () => Destroy(PauseMenuRef.gameObject);

        return window;
    }
  
    public void OnPauseButton()
    { 
        (PauseMenuRef ? OnPauseClosed : OnPauseOpened)();
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
        GameObject obj = InstantiateUIPrefab(window, ActiveWindows.transform);
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