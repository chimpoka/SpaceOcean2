using TMPro;
using UnityEngine;

public class GameHud : HudBase
{
    public TextMeshProUGUI CurrentScore;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI CurrentHealth;



    public UIEventHandler CreateStartLevelWindow()
    {
        return CreateSimpleClickableWindow("HUD/StartLevelWindow");
    }

    public UIEventHandler CreateLoseLevelWindow()
    {
        return CreateSimpleClickableWindow("HUD/LoseLevelWindow");
    }

    public UIEventHandler CreateLoseGameWindow()
    {
        return CreateSimpleClickableWindow("HUD/LoseGameWindow");
    }

    public UIEventHandler CreateHowToPlayInfoWindow()
    {
        if (GameInstance.Instance.ControllerMode == TypesHolder.ControllerMode.Accelerometer)
            return CreateSimpleClickableWindow("HUD/Tutorial/AccelerometerHowToPlayInfoWindow");
        else if (GameInstance.Instance.ControllerMode == TypesHolder.ControllerMode.Touchscreen)
            return CreateSimpleClickableWindow("HUD/Tutorial/TouchscreenHowToPlayInfoWindow");
        else
            return null;
    }

    public UIEventHandler CreateCheckpointInfoWindow()
    {
        return CreateSimpleClickableWindow("HUD/Tutorial/CheckpointInfoWindow");
    }

    public UIEventHandler CreateHealthInfoWindow()
    {
        return CreateSimpleClickableWindow("HUD/Tutorial/HealthInfoWindow");
    }



    protected UIEventHandler CreateSimpleClickableWindow(string path)
    {
        GameObject obj = InstantiateUIPrefab(path);
        UIEventHandler Event = obj.GetComponent<UIEventHandler>();

        if (Event == null)
        {
            print("Can't get UIEventHandler component from '" + path + "'");
            return null;
        }

        Event.OnClick += () => Destroy(obj);
        return Event;
    }
}