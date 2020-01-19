using TMPro;
using UnityEngine;

public class HudGame : HudBase
{
    
    public TextMeshProUGUI CurrentScore;
    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI CurrentHealth;

    public System.Action OnStartLevelWindowClosed;
    public System.Action OnLoseLevelWindowClosed;
    public System.Action OnLoseGameWindowClosed;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void CreateStartLevelWindow()
    {
        CreateSimpleClickableWindow("HUD/StartLevelWindow", OnStartLevelWindowClosed);
    }

    public void CreateLoseLevelWindow()
    {
        CreateSimpleClickableWindow("HUD/LoseLevelWindow", OnLoseLevelWindowClosed);
    }

    public void CreateLoseGameWindow()
    {
        CreateSimpleClickableWindow("HUD/LoseGameWindow", OnLoseGameWindowClosed);
    }



    private void CreateSimpleClickableWindow(string path, System.Action action)
    {
        GameObject obj = InstantiateUIPrefab(path);
        UIEventHandler Event = obj.GetComponent<UIEventHandler>();
        Event.OnClick += () => Destroy(obj);
        Event.OnClick += action;
    }
}