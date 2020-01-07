using UnityEngine;

public class HudGame : HudBase
{
    public event System.Action OnStartLevelImageClosed;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void CreateStartLevelImage()
    {
        GameObject obj = InstantiatePrefab("HUD/StartLevelImage");
        obj.GetComponent<UIEventHandler>().OnClick += DestroyWindow;
    }



    private GameObject InstantiatePrefab(string path)
    {
        GameObject obj = Instantiate(Resources.Load(path)) as GameObject;
        obj.transform.SetParent(gameObject.transform, false);
        return obj;
    }

    private void DestroyWindow(GameObject obj)
    {
        Destroy(obj);
        OnStartLevelImageClosed();
    }
}