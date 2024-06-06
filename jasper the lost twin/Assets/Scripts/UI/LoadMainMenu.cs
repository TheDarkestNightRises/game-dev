using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadMainMenu : MonoBehaviour
{
	[SerializeField]
	private SceneField startMenu;
	
	public void LoadMainMenuUI()
	{
		SceneManager.LoadScene(startMenu);
	}
	
}
