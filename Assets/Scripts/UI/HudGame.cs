using UnityEngine;

public class HudGame : HudBase
{
    public event System.Action OnStartLevelImageClosed;
    public event System.Action OnLoseLevelImageClosed;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void CreateStartLevelImage()
    {
        GameObject obj = InstantiatePrefab("HUD/StartLevelImage");
        UIEventHandler Event = obj.GetComponent<UIEventHandler>();
        Event.OnClick += () => OnStartLevelImageClosed();
        Event.OnClick += () => Destroy(obj);
    }

    public void CreateLoseLevelImage()
    {
        GameObject obj = InstantiatePrefab("HUD/LoseLevelImage");
        UIEventHandler Event = obj.GetComponent<UIEventHandler>();
        Event.OnClick += () => OnLoseLevelImageClosed();
        Event.OnClick += () => Destroy(obj);
    }

    private GameObject InstantiatePrefab(string path)
    {
        GameObject obj = Instantiate(Resources.Load(path)) as GameObject;
        obj.transform.SetParent(gameObject.transform, false);
        return obj;
    }

 
}