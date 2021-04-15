using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TPReticleTimer : MonoBehaviour
{
    public Image imgTimer;
    public float timeTotal;
    public float timeCurrent;
    public bool isEnable;
    public UnityEvent[] timerEvents;
    public int idEvent;

    void Start()
    {
        imgTimer.fillAmount = 0f;
    }

    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if(isEnable)
        {
            timeCurrent += Time.deltaTime;
            imgTimer.fillAmount = timeCurrent/timeTotal;
        }

        if(timeCurrent >= timeTotal)
        {
            isEnable=false;
            timerEvents[idEvent].Invoke();
        }
    }

    public void TimerEnter(int _ID)
    {
        isEnable = true;
        idEvent = _ID;
    }

    public void TimerExit()
    {
        isEnable = false;
        timeCurrent=0f;
        imgTimer.fillAmount = 0f;
    }

}
