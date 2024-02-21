using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerStats", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
	
	[Header("MoveStats")]
    public float movementVelocity = 10f;
	
	[Header("JumpStats")]
	public float jumpVelocity = 15f;
	public int amountOfJumps = 1;
	
	[Header("Check variables")]
	public float groundCheckRadius = 0.3f;
	public LayerMask whatIsGround;
}
