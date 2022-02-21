using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float totalTimeToDestroy;
	public bool countDownOnStart;
	
	private CountDownState countDownState = CountDownState.Stopped;
	private float lastRemainingTime;
	private float timeWhenStarted;
	
	private void Start()
	{
		if(countDownOnStart)
		{
			StartCountDown();
		}
	}

    private void OnDestroy()
    {
		CancelInvoke("CountDownEnded");
	}

    public void StartCountDown()
	{
		lastRemainingTime = totalTimeToDestroy;
		Invoke("CountDownEnded", lastRemainingTime);
		countDownState = CountDownState.Started;
		timeWhenStarted = Time.time;
	}

	public void StopCountDown()
	{
		if(countDownState != CountDownState.Stopped)
		{
			CancelInvoke("CountDownEnded");
			countDownState = CountDownState.Stopped;
		}
	}
	
	public void PauseCountDown()
	{
		if(countDownState != CountDownState.Started)
		{
			lastRemainingTime = GetRemainingTime();
			CancelInvoke("CountDownEnded");
			countDownState = CountDownState.Paused;
		}
	}
	
	public void ResumeCountDown()
	{
		if(countDownState != CountDownState.Paused)
		{
			Invoke("CountDownEnded", lastRemainingTime);
			countDownState = CountDownState.Started;
			timeWhenStarted = Time.time;
		}
	}
	
	private void CountDownEnded()
	{
		Destroy(gameObject);
	}
	
	public CountDownState GetCountDownState()
	{
		return countDownState;
	}
	
	public float GetRemainingTime()
	{
		if(countDownState != CountDownState.Started)
		{
			return lastRemainingTime + timeWhenStarted - Time.time;
		}
		return -1;
	}
	
	public enum CountDownState
	{
		Stopped,
		Started,
		Paused
	}
	
}
