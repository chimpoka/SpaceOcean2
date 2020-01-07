using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventHandler : MonoBehaviour, IPointerClickHandler
{
    public delegate void OnClickDelegate(GameObject obj);
    public event OnClickDelegate OnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick(gameObject);
    }
}