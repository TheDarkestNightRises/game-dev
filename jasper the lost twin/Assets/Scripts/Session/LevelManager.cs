using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		if(instance == null) instance = this;
		else Destroy(gameObject);
	}
	
	public void Gameover()
	{
		UIManager ui = GetComponent<UIManager>();
		StartCoroutine(ui.ShowDeathUiAfterDelay(1f)); 
	}
	
}
