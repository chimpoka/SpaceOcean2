using TMPro;
using UnityEngine;

public class MainMenuHud : HudBase
{
    public System.Action OnPlay;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPlayButton()
    {
        OnPlay();
    }
}