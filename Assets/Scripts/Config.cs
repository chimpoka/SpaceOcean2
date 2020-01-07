using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects / Config")]
public class Config : SingletonScriptableObject<Config>
{
    public float StartSpeed = 5.0f;
}
