using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuWindow : MonoBehaviour
{
    public System.Action OnBack;


    public void OnBackButton()
    {
        OnBack();
    }
}
