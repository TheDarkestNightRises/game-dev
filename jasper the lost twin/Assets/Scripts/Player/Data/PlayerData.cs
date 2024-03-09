﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerStats", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
	[Header("MoveStats")]
	public float movementVelocity = 15f;
	public float runAccell = 5f;
	public float decAccell = 3f;
	
	[Header("JumpStats")]
	public float jumpVelocity = 10f;
	public int amountOfJumps = 2;
}
