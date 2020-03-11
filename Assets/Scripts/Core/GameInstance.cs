using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects / GameInstance")]
public class GameInstance : ScriptableObject
{
    static GameInstance _instance = null;
    public static GameInstance Instance
    {
        get
        {
            _instance = _instance ?? Resources.LoadAll<GameInstance>("").FirstOrDefault();
            return _instance;
        }
    }

    public TypesHolder.ControllerMode ControllerMode;
    public TypesHolder.PlayMode PlayMode;
    public Config Config;
    public LevelLoader LevelLoader;
    public AudioManager AudioManager;
}