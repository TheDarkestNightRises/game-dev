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
	
	public void StartGame()
	{
		SceneManager.LoadSceneAsync(_persistentScene);
		SceneManager.LoadSceneAsync(_firstLevel, LoadSceneMode.Additive);
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
