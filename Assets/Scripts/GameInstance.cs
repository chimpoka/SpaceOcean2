using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(menuName = "Singleton / GameInstance")]
public class GameInstance : ScriptableObject
{
    public EnumsHolder.ControllerMode ControllerMode;
    public EnumsHolder.PlayMode PlayMode;

    static private GameInstance instance = null;
    static public GameInstance Instance
    {
        get
        {
            if (!instance)
                instance = Resources.FindObjectsOfTypeAll<GameInstance>().FirstOrDefault();
            return instance;
        }
    }

    public void LoadMainMenuScene()
    {

    }

    public void LoadGameScene(EnumsHolder.ControllerMode playMode, EnumsHolder.ControllerMode controllerMode)
    {

    }
}