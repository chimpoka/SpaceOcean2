using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Action function;

    public void LaunchRepeating(Action func, float delay, float repeatRate)
    {
        function = func;
        InvokeRepeating("InvokeInternal", delay, repeatRate);
    }

    public void Launch(Action func, float delay)
    {
        function = func;
        Invoke("InvokeInternal", delay);
    }

    public void StopTimer()
    {
        CancelInvoke();
        function = null;
    }

    private void InvokeInternal()
    {
        if (function != null)
            function.Invoke();
    }
}
