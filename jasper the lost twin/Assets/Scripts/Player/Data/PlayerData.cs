using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerStats", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
	[Header("MoveStats")]
	public float movementVelocity = 10f;
	public float runAccell = 9f;
	public float decAccell = 8f;
	
	[Header("JumpStats")]
	public float jumpVelocity = 17f;
	public int amountOfJumps = 2;
	public float coyoteTime = 0.2f;
	public float jumpHoldMultiplier = 0.5f;
	
	[Header("FallingStats")]
	public float maximumFallingSpeed = 13f;
	public float fallGravityMultiplier = 1.5f;
	public float gravityScale = 2.5f;
}
