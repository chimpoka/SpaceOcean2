using System.Collections;
using UnityEngine;

public class IntegerTimer : MonoBehaviour
{
    public delegate void OnTimerTickedDelegate(int secondsRemain);
    public event OnTimerTickedDelegate OnTimerTicked;

    private IEnumerator StartTimerInternal(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            if (OnTimerTicked != null)
                OnTimerTicked(i);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void StartTimer(int seconds)
    {
        StartCoroutine(StartTimerInternal(seconds));
    }
}
