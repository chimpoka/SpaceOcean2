using TMPro;
using UnityEngine;

public class HudMainMenu : HudBase
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