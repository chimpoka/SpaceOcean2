using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    
    public TypesHolder.OnCheckpointActivatedDelegate OnActivated;

    private void OnTriggerEnter(Collider other)
    {
        OnActivated(this);
    }
}
