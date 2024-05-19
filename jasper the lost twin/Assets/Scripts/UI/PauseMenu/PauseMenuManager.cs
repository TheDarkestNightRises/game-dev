using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
	public GameObject pauseMenuCanvas;

	private void Start()
	{
		PlayerInputHandler.OnPause += OpenPauseMenu;
	}

	private void OnDestroy()
	{
		PlayerInputHandler.OnPause -= OpenPauseMenu;
	}

	private void OpenPauseMenu()
	{
		if (pauseMenuCanvas != null)
		{
			bool isPaused = pauseMenuCanvas.activeSelf;
			pauseMenuCanvas.SetActive(!isPaused);

			if (isPaused)
			{
				Time.timeScale = 1f;
			}
			else
			{
				Time.timeScale = 0f;
			}
		}
		else
		{
			Debug.LogWarning("Pause menu canvas is not assigned in the inspector.");
		}
	}

}
