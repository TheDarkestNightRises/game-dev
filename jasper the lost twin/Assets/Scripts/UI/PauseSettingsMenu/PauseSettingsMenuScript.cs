using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSettingsMenuScript : MonoBehaviour
{
	public static PauseSettingsMenuScript Instance { get; private set; }
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

	public void TogglePauseSettingsMenu()
	{
		if (pauseMenuCanvas != null)
		{
			bool isPaused = !pauseMenuCanvas.activeSelf;
			pauseMenuCanvas.SetActive(isPaused);
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
