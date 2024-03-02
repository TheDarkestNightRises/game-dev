using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] private GameObject[] _objectsToHide;
	[SerializeField] private GameObject _loadingBarObject;
	[SerializeField] private string _firstLevel = "Level_1";
	[SerializeField] private string _persistentScene = "PersistScene";
	
	public void StartGame()
	{
		HideMenu();
		SceneManager.LoadSceneAsync(_persistentScene);
		SceneManager.LoadSceneAsync(_firstLevel, LoadSceneMode.Additive);
	}	

	private void HideMenu()
	{
		foreach (GameObject objToHide in _objectsToHide)
		{
			objToHide.SetActive(false);
		}
	}
}
