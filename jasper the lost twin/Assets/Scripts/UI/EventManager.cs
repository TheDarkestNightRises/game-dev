using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	public static EventManager instance;

	public delegate void PauseEvent();
	public event PauseEvent OnPause;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	public void TriggerPauseEvent()
	{
		OnPause();
	}
}
