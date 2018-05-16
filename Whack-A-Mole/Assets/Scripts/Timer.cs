using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public int startTime;

    private WaitForSeconds _wait = new WaitForSeconds(1);
    private int _time;

    public UnityAction OnTimeOut;

    public void Restart()
    {
        _time = startTime;
        timerText.text = startTime.ToString();
        StartCoroutine("StartTimer");
    }

    IEnumerator StartTimer()
    {
        while(true)
        {
            yield return _wait;
            _time--;
            timerText.text = _time.ToString();
            if (_time == 0)
                break;
        }
        OnTimeOut();
    }
}
