using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Countdown : MonoBehaviour
{
    public static Countdown Instance { get; private set; }
    public event Action<Countdown, CountdownEventArgs> OnBuildLevelEvent;

    public class CountdownEventArgs : EventArgs
    {
        public int countDownTime;
    }

    private TextMeshProUGUI countdownText;
    private int countDown;

    private float timer;
    private int timerMax;

    private int prizeStarCount;

    public bool allowToCountDown;
    private void Awake()
    {
        Instance = this;
        countdownText = transform.Find("countdownText").GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        OnBuildLevelEvent += Countdown_OnBuildLevelEvent;
    }
    private void OnDisable()
    {
        OnBuildLevelEvent -= Countdown_OnBuildLevelEvent;
    }

  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsCountDownZero() && allowToCountDown)
        {
            if (HDGameManager.Instance.SectionPassedCompleted())
            {
                FixCountdownAfterLevelCompleted();
            }
            else
            {
                SetTimerForCountDown();
            }
           
        }
        
        
    }

    private void CountDownTimer()
    {
        countDown -= 1;
        countDown = Mathf.Clamp(countDown, 0, 30);
        if(countDown >= 10)
        {
            countdownText.text = countDown.ToString();
        }
        else
        {
            countdownText.text = "0" + countDown;
        }
    }

    private void SetTimerForCountDown()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timerMax = 1;
            timer += timerMax;
            CountDownTimer();
        }
    }
    public bool IsCountDownZero()
    {
        return countDown == 0;
    }

   private int FixCountdownAfterLevelCompleted()
    {
        int fixCountdown = countDown;

        countDown = fixCountdown;

        return countDown;
    }

    public int GetPrizeStarCounts()
    {
        if(FixCountdownAfterLevelCompleted() >= 20)
        {
            prizeStarCount = 3;
        }
        else if(FixCountdownAfterLevelCompleted() >= 10)
        {
            prizeStarCount = 2;
        }
        else if(FixCountdownAfterLevelCompleted() >= 0)
        {
            prizeStarCount = 1;
        }
        return prizeStarCount;
    }
    public void CallOnBuildLevelEvent(int countDownStartTime)
    {
        OnBuildLevelEvent?.Invoke(this, new CountdownEventArgs() { countDownTime = countDownStartTime }); 
    }

    private void Countdown_OnBuildLevelEvent(Countdown countdown,CountdownEventArgs countdownEventArgs)
    {
        countDown = countdownEventArgs.countDownTime;
        countdownText.text = countDown.ToString();
    }
}
