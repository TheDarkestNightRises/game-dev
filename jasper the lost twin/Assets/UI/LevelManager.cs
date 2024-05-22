using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		if(LevelManager.instance == null) instance = this;
		else Destroy(gameObject);
	}
	
	public void Gameover()
	{
		UIManager ui = GetComponent<UIManager>();
		ui.ShowDeathUi();
	}
	
}
