using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects / GameInstance")]
public class GameInstance : SingletonScriptableObject<GameInstance>
{
    public TypesHolder.ControllerMode ControllerMode;
    public TypesHolder.PlayMode PlayMode;
    public LevelLoader LevelLoader;
    public AudioManager AudioManager;
}