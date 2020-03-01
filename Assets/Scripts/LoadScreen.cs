using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    public System.Action OnFadeInCompleted;
    public System.Action OnFadeOutCompleted;



    public void FadeIn()
    {
        GetComponent<Animator>().SetTrigger("End");
    }

    public void FadeOut()
    {
        GetComponent<Animator>().SetTrigger("Start");
    }



    void OnFadeInAnimationEnd()
    {
        OnFadeInCompleted();
    }

    void OnFadeOutAnimationEnd()
    {
        OnFadeOutCompleted();
    }
}