using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{

	[SerializeField] private SceneField _mainMenu;

	public void BackToMainMenu() 
	{
		SceneManager.LoadSceneAsync(_mainMenu);
	}
}
