using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public System.Action OnActivate;

    private void OnTriggerEnter(Collider other)
    {
        OnActivate();
    }
}
