using System;
using System.Collections;
using TMPro;
using UnityEngine;

public sealed class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    private int _time;

    public IEnumerator TimerCoroutine(int time, Action onTimerFinished)
    {
        _time = time;
        while (_time > 0)
        {
            TimeCount();
            yield return new WaitForSeconds(1);
        }

        onTimerFinished?.Invoke();
    }

    private void TimeCount()
    {
        _time -= 1;
        timeText.text = _time.ToString();
    }
}