using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] private SceneField _firstLevel;
	[SerializeField] private SceneField _persistentScene;
	[SerializeField] private SceneField _settingsMenu;
	[SerializeField] private SceneField _mainMenu;
	[SerializeField] private SceneField _pauseMainMenu;
	public AudioClip mainMenuMusic;
	
	
	void Start()
	{
		AudioManager.instance.PlayMusic(mainMenuMusic);
	}
	
	
	public void StartGame()
	{
		AudioManager.instance.StopMusic();
		SceneManager.LoadSceneAsync(_persistentScene);
		SceneManager.LoadSceneAsync(_firstLevel, LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync(_pauseMainMenu);

	}	
	
	public void OpenSettings()
	{
		SceneManager.LoadSceneAsync(_settingsMenu);
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
	
	public void BackToMainMenu() 
	{
		SceneManager.LoadSceneAsync(_mainMenu);
	}

}
