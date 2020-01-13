using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects / Config")]
public class Config : SingletonScriptableObject<Config>
{
    public float StartSpeed = 5.0f;
    public int MaxHealth = 5;

    [Header("Checkpoints")]
    public int CheckpointsCount = 10;
    public float StartCheckpointScore = 20.0f;
    public float CheckpointsInterval = 40.0f;
}
