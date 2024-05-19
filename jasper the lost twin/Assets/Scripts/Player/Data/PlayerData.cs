using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerStats", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
	[Header("Layers")]
	public LayerMask whatIsGround;
	public LayerMask whatIsPlayer;
	
	[Header("MoveStats")]
	public float movementVelocity = 10f;
	public float runAccell = 9f;
	public float decAccell = 8f;
	public float friction = 0.2f;
	
	[Header("JumpStats")]
	public float jumpVelocity = 17f;
	public int amountOfJumps = 2;
	public float coyoteTime = 0.2f;
	public float jumpHoldMultiplier = 0.5f;
	
	[Header("FallingStats")]
	public float maximumFallingSpeed = 13f;
	public float fallGravityMultiplier = 1.5f;
	public float gravityScale = 2.5f;
	
	[Header("DashState")]
	public float dashCooldown = 0.5f;
	public float maxHoldTime = 1f;
	public float holdTimeScale = 0.25f;
	public float dashTime = 0.2f;
	public float dashVelocity = 10f;
	public float drag = 10f;
	public float dashEndYMultiplayer = 0.2f;
	public float distacenBetweenAfterImages = 0.5f;
		
	[Header("Death")]
	public float deathKick = 2f;
	public float deathImpulse = 1f;
	public Vector2 deathKickDirection = new Vector2(10f, 10f);
	
	[Header("Hit")]
	public float stunTime = 0.5f;
	public float invincibilityTime = 1f; 

	[Header("Health")]
	public float maxHealth = 300f;
	
	[Header("Attack")]
	public float speedWhileAttacking = 4f;
	
	[Header("Climb")]
	public float climbSpeed = 10f;
}
