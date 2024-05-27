using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
	public static GameSession instance;
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

	private void ResetGameSession()
	{
		SceneManager.LoadScene(0);
		FindObjectOfType<DontDestroyOnLoad>().ResetScenePersist();
		Destroy(gameObject);
	}
}
