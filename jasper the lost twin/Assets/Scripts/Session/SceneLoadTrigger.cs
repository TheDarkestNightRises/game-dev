using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
	[SerializeField] private string _sceneToLoad;
	[SerializeField] private string _sceneToUnload;
	
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("TRIGGER SCENE LOAD");
			LoadScene();
			UnloadScene();
		}
	}
	
	private void LoadScene()
	{
		SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive);
	}
	
	private void UnloadScene()
	{
		SceneManager.UnloadSceneAsync(_sceneToUnload);
	}
}
