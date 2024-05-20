using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSettingsMenuScript : MonoBehaviour
{
	public static PauseSettingsMenuScript Instance { get; private set; }
	public GameObject pauseSettingsCanvas;
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
		if (pauseSettingsCanvas != null)
		{
			pauseSettingsCanvas.SetActive(false);
		}
	}

	public void TogglePauseSettingsMenu()
	{
		if (pauseMenuCanvas != null)
		{
			pauseSettingsCanvas.SetActive(false);
			pauseMenuCanvas.SetActive(true);
		}
	}
	

}
