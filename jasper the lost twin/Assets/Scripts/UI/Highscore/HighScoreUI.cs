using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI highScoreText;

	private void Awake()
	{
		highScoreText = GetComponent<TextMeshProUGUI>();
	}
	private void OnEnable()
	{
		ResourceEvents.highScoreIncreased += OnHighScoreIncreased;
	}

	private void OnDisable()
	{
		ResourceEvents.highScoreIncreased -= OnHighScoreIncreased;
	}

	private void OnHighScoreIncreased(GameObject player, float newHighScore)
	{
		highScoreText.text = newHighScore.ToString("0000");
	}

}
