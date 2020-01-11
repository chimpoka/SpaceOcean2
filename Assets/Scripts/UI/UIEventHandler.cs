using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventHandler : MonoBehaviour, IPointerClickHandler
{
    public event System.Action OnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}