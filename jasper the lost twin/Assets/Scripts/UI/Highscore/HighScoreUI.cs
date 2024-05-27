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
	
	public void Start()
	{
		SetText(GameSession.instance.highScore);
	}
	
	private void OnEnable()
	{
		ResourceEvents.HighScoreIncreased += OnHighScoreIncreased;
	}

	private void OnDisable()
	{
		ResourceEvents.HighScoreIncreased -= OnHighScoreIncreased;
	}

	private void OnHighScoreIncreased(GameObject player, float newHighScore)
	{
		SetText(newHighScore);
	}
		
	private void SetText(float newHighScore)
	{
		highScoreText.text = newHighScore.ToString("0000");
	}
}
