using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
	[SerializeField] private SceneField[] _sceneToLoad;
	[SerializeField] private SceneField[] _sceneToUnload;
	
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			LoadScenes();
			UnloadScenes();
		}
	}
	
	private void LoadScenes()
	{		
		foreach (SceneField scene in _sceneToLoad)
		{
			if (!IsSceneLoaded(scene))
			{
				LoadSceneAsync(scene);
			}
		}
	}
	
	private bool IsSceneLoaded(SceneField scene)
	{
		foreach (Scene loadedScene in SceneManager.GetAllScenes())
		{
			if (scene.SceneName == loadedScene.name)
			{
				return true;
			}
		}
		return false;
	}
	
	private void LoadSceneAsync(SceneField scene)
	{
		SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
	}

	private void UnloadScenes()
	{
		foreach (SceneField scene in _sceneToUnload)
		{
			UnloadSceneAsync(scene);
		}
	}
	
	private void UnloadSceneAsync(SceneField scene)
	{
		SceneManager.UnloadSceneAsync(scene);
	}
}
