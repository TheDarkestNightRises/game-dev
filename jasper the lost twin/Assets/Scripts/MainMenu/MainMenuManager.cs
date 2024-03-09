using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] private SceneField _firstLevel;
	[SerializeField] private SceneField _persistentScene;
	
	public void StartGame()
	{
		SceneManager.LoadSceneAsync(_persistentScene);
		SceneManager.LoadSceneAsync(_firstLevel, LoadSceneMode.Additive);
	}	

}
