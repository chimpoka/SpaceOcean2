using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    
    public TypesHolder.OnCheckpointActivatedDelegate OnActivated;
    public bool IsActivated = false;


    private void OnTriggerStay(Collider other)
    {
        if (IsActivated)
            return;

        if (other.transform.position.x > transform.position.x)
        {
            OnActivated(this);
            IsActivated = true;
        }
    }
}
