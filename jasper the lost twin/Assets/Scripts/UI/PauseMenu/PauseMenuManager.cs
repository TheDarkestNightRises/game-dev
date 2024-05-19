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
		if (pauseMenuCanvas != null)
		{
			pauseMenuCanvas.SetActive(false);
		}

		Debug.Log("Subscribing to OnPause event...");
		PlayerInputHandler.OnPause += OpenPauseMenu;
	}

	private void OnDestroy()
	{
		Debug.Log("Unsubscribing from OnPause event...");
		PlayerInputHandler.OnPause -= OpenPauseMenu;
	}

	private void OpenPauseMenu()
	{
		Debug.Log("Pause menu opened.");
		if (pauseMenuCanvas != null)
		{
			bool isPaused = !pauseMenuCanvas.activeSelf;
			pauseMenuCanvas.SetActive(isPaused);
		}
		else
		{
			Debug.LogWarning("Pause menu canvas is not assigned in the inspector.");
		}
	}
}
