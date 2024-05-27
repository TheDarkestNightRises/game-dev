using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
	public static SceneLoadManager instance;
	
	protected void Awake()
	{
		if (instance is null)
		{
			instance = this;
		}
	}
	
	protected void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		Debug.Log("SCENE LOADED");
		MapManager.instance.RevealRoom(scene);
	}
}
