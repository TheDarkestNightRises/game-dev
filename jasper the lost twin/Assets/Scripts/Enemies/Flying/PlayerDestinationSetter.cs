using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIDestinationSetter : VersionedMonoBehaviour {
	/// <summary>The object that the AI should move to</summary>
	IAstarAI ai;
	private Transform player;

	protected override void Awake()
	{
		base.Awake();
		player = GameObject.FindWithTag("Player").transform;
	}
	
	void OnEnable () {
		ai = GetComponent<IAstarAI>();
		// Update the destination right before searching for a path as well.
		// This is enough in theory, but this script will also update the destination every
		// frame as the destination is used for debugging and may be used for other things by other
		// scripts as well. So it makes sense that it is up to date every frame.
		if (ai != null) ai.onSearchPath += Update;
	}

	void OnDisable () {
		if (ai != null) ai.onSearchPath -= Update;
	}

	/// <summary>Updates the AI's destination every frame</summary>
	void Update () {
		if (player != null && ai != null) ai.destination = player.position;
	}
}
