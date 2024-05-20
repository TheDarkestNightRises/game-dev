using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
	public static PauseMenuManager Instance { get; private set; }
	public GameObject pauseMenuCanvas;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject); 
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		if (pauseMenuCanvas != null)
		{
			pauseMenuCanvas.SetActive(false);
		}
	}

	public void TogglePauseMenu()
	{
		if (pauseMenuCanvas != null)
		{
			bool isPaused = !pauseMenuCanvas.activeSelf;
			pauseMenuCanvas.SetActive(isPaused);
		}
	}
	
	public void Resume() {
		pauseMenuCanvas.SetActive(false);
	}
}
