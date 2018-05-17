using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public Text timerText;
    
    /// <summary>
    /// The time of the game round.
    /// </summary>
    public int startTime;

    private WaitForSeconds wait = new WaitForSeconds(1);
    private int time;

    public UnityAction OnTimeOut;

    /// <summary>
    /// Reset the timer, called at new game.
    /// </summary>
    public void NewGame()
    {
        time = startTime;
        timerText.text = startTime.ToString();
        StartCoroutine("StartTimer");
    }

    IEnumerator StartTimer()
    {
        while(true)
        {
            yield return wait;
            time--;
            timerText.text = time.ToString();
            if (time == 0)
                break;
        }
        OnTimeOut();
    }
}
