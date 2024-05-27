using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
	[SerializeField] private SceneField _mainMenu;
	
	public void Retry() 
	{
		var scene = SceneManager.GetSceneAt(1).buildIndex;
		SceneManager.LoadSceneAsync(0);
		SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
		Destroy(gameObject);
	}
	
	public void Exit() {
		SceneManager.LoadSceneAsync(_mainMenu);
		Destroy(gameObject);
	}
}
