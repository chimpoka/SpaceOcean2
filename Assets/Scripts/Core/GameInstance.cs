using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects / GameInstance")]
public class GameInstance : SingletonScriptableObject<GameInstance>
{
    public TypesHolder.ControllerMode ControllerMode;
    public TypesHolder.PlayMode PlayMode;
    public bool PlayTutorial;

    public void LoadMainMenuScene()
    {

    }

    public void LoadGameScene(TypesHolder.ControllerMode playMode, TypesHolder.ControllerMode controllerMode)
    {

    }
}