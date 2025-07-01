using System;

using TMPro;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{

    public event Action OnTimeOver;
    [SerializeField] protected float timeRemaining;
    public float TimeRemaining => timeRemaining;
    [SerializeField] protected float startMinutesValue = 3f;
    [SerializeField] protected bool isTimerRunning = true;
    public bool IsTimerRunning => isTimerRunning;


    protected override void Start()
    {
        base.Start();
        timeRemaining = startMinutesValue * 60;
        OnTimeOver += GameStateManager.Instance.GameOver;

    }

    protected virtual void FixedUpdate()
    {
        if (!isTimerRunning) return;
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            isTimerRunning = false;
            Debug.Log("OnTimeOver");
            OnTimeOver?.Invoke();
            return;
        }

        timeRemaining -= Time.deltaTime;

    }

    public virtual void ResetTime()
    {
        timeRemaining = startMinutesValue * 60;

    }
    public virtual int GetStarRating()
    {
        return  StarRatingSystem.CalculateStarCount(timeRemaining, startMinutesValue * 60);
    }
}
