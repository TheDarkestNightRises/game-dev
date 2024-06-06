using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerInteractable : TriggerInteractBase
{
	public enum DoorSpawnAt
	{
		None,
		One,
		Two,
		Three,
		Four
	}
	
	[Space(10f)]
	public DoorSpawnAt CurrentDoorPosition;
	
	[SerializeField] 
	private SceneField _sceneToLoad;
	public DoorSpawnAt DoorToSpawnTo;

	
	public override void Interact()
	{
		SceneSwapManager.SwapSceneFromDoorUse(_sceneToLoad, DoorToSpawnTo);
	}
}
