using UnityEngine;
using TMPro;

public class BestScoreUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI highScoreText;
	private const string HighScoreKey = "HighScore";

	private void Start()
	{
		LoadBestScore();
	}
    
	private void SetText(float newHighScore)
	{
		highScoreText.text = newHighScore.ToString("0000");
	}

	private void LoadBestScore()
	{
		var highScore = PlayerPrefs.GetFloat(HighScoreKey, 0f);
		SetText(highScore);
	}
}
