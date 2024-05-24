using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSesion : MonoBehaviour
{
	public static GameSesion instance;
	[SerializeField]
	private float highScore = 0f;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		if(LevelManager.instance == null) instance = this;
		else Destroy(gameObject);
	}
	
	public void AddToScore(float pointsToAdd)
	{
		highScore += pointsToAdd;
		Debug.Log(ResourceEvents.highScoreIncreased);
		Debug.Log(this.gameObject);

		ResourceEvents.highScoreIncreased.Invoke(gameObject, highScore);
	}

}
