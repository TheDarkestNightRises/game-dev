using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSettingsMenuScript : MonoBehaviour
{
	public static PauseSettingsMenuScript Instance { get; private set; }
	public GameObject pauseSettingsMenuCanvas;

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
		if (pauseSettingsMenuCanvas != null)
		{
			pauseSettingsMenuCanvas.SetActive(false);
		}
	}

	public void TogglePauseSettingsMenu()
	{
		if (pauseSettingsMenuCanvas != null)
		{
			bool isPaused = !pauseSettingsMenuCanvas.activeSelf;
			pauseSettingsMenuCanvas.SetActive(isPaused);
		}
	}
	
	//public void Resume() {
	//	pauseMenuCanvas.SetActive(false);
	//}
	
	//public void Exit() {
	//	SceneManager.LoadSceneAsync(_mainMenu);
	//	Destroy(gameObject);
	//}
}
