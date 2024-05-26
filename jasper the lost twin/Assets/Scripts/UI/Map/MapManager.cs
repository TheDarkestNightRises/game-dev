using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
	public static MapManager instance;
	private MapRoom[] _rooms;
	
	protected void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		
		_rooms = GetComponentsInChildren<MapRoom>(true);
	}
	
	public void RevealRoom(Scene scene)
	{
		Debug.Log(scene.name);
		foreach (MapRoom room in _rooms)
		{
			if (room.RoomScene.SceneName == scene.name && !room.HasBeenRevealed)
			{
				room.gameObject.SetActive(true);
				room.HasBeenRevealed = true;
				
				return;
			}
		}
	}
}
