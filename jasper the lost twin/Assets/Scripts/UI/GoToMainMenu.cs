using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
	[SerializeField]
	public SceneField mainMenu;
	
	public void LoadMainMenu()
	{
		GameSession.instance.ResetGameSession();
	}
}
