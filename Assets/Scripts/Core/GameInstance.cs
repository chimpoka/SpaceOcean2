using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects / GameInstance")]
public class GameInstance : SingletonScriptableObject<GameInstance>
{
    public EnumsHolder.ControllerMode ControllerMode;
    public EnumsHolder.PlayMode PlayMode;

    public void LoadMainMenuScene()
    {

    }

    public void LoadGameScene(EnumsHolder.ControllerMode playMode, EnumsHolder.ControllerMode controllerMode)
    {

    }
}