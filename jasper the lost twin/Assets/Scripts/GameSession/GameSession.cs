using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour
{
	[SerializeField] float gold = 0;
	[SerializeField] TextMeshProUGUI goldText;

	void Awake()
	{
		int numberOfGamesession = FindObjectsOfType<GameSession>().Length;
		if (numberOfGamesession > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}
	private void Start()
	{
		goldText.text = gold.ToString();
	}

	public void ProcessPlayerDeath()
	{
		ResetGameSession();
	}

	public void AddToScore(int pointsToAdd)
	{
		gold += pointsToAdd;
		Debug.Log(gold);
		Debug.Log("gold has increased");
		goldText.text = gold.ToString();
	}

	private void TakeLife()
	{
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentIndex);
	}

	private void ResetGameSession()
	{
		SceneManager.LoadScene(0);
		FindObjectOfType<ScenePersist>().ResetScenePersist();
		Destroy(gameObject);
	}
}
