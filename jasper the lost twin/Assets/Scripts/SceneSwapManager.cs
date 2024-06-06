using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : MonoBehaviour
{
	public static SceneSwapManager instance;
	private DoorTriggerInteractable.DoorSpawnAt _doorSpawnAt;
	private GameObject _player;
	private Collider2D _playerColl;
	private Collider2D _doorColl;
	private bool _loadFromDoor = false;

	private Vector3 _playerSpawnPosition;
	
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		
		_player = GameObject.FindGameObjectWithTag("Player");
	}
	
	public static void SwapSceneFromDoorUse(SceneField myScene, DoorTriggerInteractable.DoorSpawnAt doorSpawnAt)
	{
		instance.StartCoroutine(instance.FadeOutThenChangeScene(myScene, doorSpawnAt));
	}
	
	private IEnumerator FadeOutThenChangeScene(SceneField myScene, DoorTriggerInteractable.DoorSpawnAt doorSpawnAt = DoorTriggerInteractable.DoorSpawnAt.None)
	{
		SceneFadeManager.instance.StartFadeOut();
		
		while (SceneFadeManager.instance.isFadingOut)
		{
			yield return null;
		}
		
		_doorSpawnAt = doorSpawnAt;
		SceneManager.LoadScene(myScene);
	}
	
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		SceneFadeManager.instance.StartFadeIn();	
		
		if(_loadFromDoor)
		{
			FindDoor(_doorSpawnAt);
			_player.transform.position = _playerSpawnPosition;	
			_loadFromDoor = false;
		}
	}
	
	private void FindDoor(DoorTriggerInteractable.DoorSpawnAt doorSpawnNumber)
	{
		DoorTriggerInteractable[] doors = FindObjectsOfType<DoorTriggerInteractable>();
		
		for (int i=0; i < doors.Length ; i++)
		{
			if (doors[i].CurrentDoorPosition == doorSpawnNumber)
			{
				_doorColl = doors[i].gameObject.GetComponent<Collider2D>();
					
				CalculateSpawnPoint();
				return;
			}
		}
	}
	
	private void CalculateSpawnPoint()
	{
		float colliderHeight = _playerColl.bounds.center.y;
		_playerSpawnPosition = _doorColl.transform.position - new Vector3(0f, colliderHeight, 0f);
	}
}
