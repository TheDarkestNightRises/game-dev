using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
	void Awake()
	{
		int numScenePersists = FindObjectsOfType<DontDestroyOnLoad>().Length;
		if (numScenePersists > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}
	public void ResetScenePersist()
	{
		Destroy(gameObject);
	}
}
