using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
	public static PauseMenuManager Instance { get; private set; }
	public GameObject pauseMenuCanvas;
	public GameObject pauseSettingsMenuCanvas;
	[SerializeField] private SceneField _mainMenu;
	private List<Animator> _animators;

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
		
		_animators = new List<Animator>();
		_animators.AddRange(pauseMenuCanvas.GetComponentsInChildren<Animator>(true));
		_animators.AddRange(pauseSettingsMenuCanvas.GetComponentsInChildren<Animator>(true));

		foreach (var animator in _animators)
		{
			animator.updateMode = AnimatorUpdateMode.UnscaledTime;
		}
	}

	public void TogglePauseMenu()
	{
		if (pauseMenuCanvas != null)
		{
			bool isPaused = !pauseMenuCanvas.activeSelf;
			pauseMenuCanvas.SetActive(isPaused);
			Time.timeScale = isPaused ? 0 : 1;
		}
	}
	
	public void Resume() {
		pauseMenuCanvas.SetActive(false);
		Time.timeScale = 1;
	}
	
	public void Exit() {
		Time.timeScale = 1;
		SceneManager.LoadSceneAsync(_mainMenu);
		Destroy(gameObject);
	}
	
	public void TogglePauseSettingsMenu()
	{
		if (pauseSettingsMenuCanvas != null)
		{
			pauseSettingsMenuCanvas.SetActive(true);
			pauseMenuCanvas.SetActive(false);
		}
	}
	
	
}
