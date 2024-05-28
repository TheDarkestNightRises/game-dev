using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
	public static GameSession instance;
	private const string HighScoreKey = "HighScore";
	[SerializeField] public float highScore = 0f;
	[SerializeField] public float gold = 0f;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}
	
	public void AddToScore(float pointsToAdd)
	{
		highScore += pointsToAdd;
		ResourceEvents.HighScoreIncreased.Invoke(gameObject, highScore);
	}
	
	public void AddToGold(int goldToAdd)
	{
		gold += goldToAdd;
		ResourceEvents.GoldIncreased.Invoke(gameObject, gold);
	}
	
	public void WinGame()
	{
		SaveScore();
	}
	
	public void ResetGameSession()
	{
		SceneManager.LoadScene(0);
		Destroy(gameObject);
	}
	
	private void SaveScore()
	{
		var previousHighscore = PlayerPrefs.GetFloat(HighScoreKey, 0f);
		Debug.Log(previousHighscore);
		if (highScore > previousHighscore)
		{
			PlayerPrefs.SetFloat(HighScoreKey, highScore);
		}
		
		PlayerPrefs.Save();
	}
}
