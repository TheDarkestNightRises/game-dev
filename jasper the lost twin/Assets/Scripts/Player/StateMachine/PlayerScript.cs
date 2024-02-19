using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	#region States
	public PlayerStateMachine StateMachine { get; set;}
	public PlayerIdleState IdleState {get; set;}
	public PlayerMoveState MoveState {get; set;}
	#endregion
	
	public Animator Anim { get; set; }
	public PlayerInputHandler InputHandler { get; set;}
	public Rigidbody2D RB { get; set;} 
	public Vector2 CurrentVelocity { get; set;}
	
	public void Update()
	{
	 CurrentVelocity = RB.velocity;	
	}
	
	public void SetVelocityX(float velocityX) 
	{
		Vector2 velocity = new Vector2(velocityX, CurrentVelocity.y);
		RB.velocity = velocity;
	}
	
	public void SetVelocityY(float velocityY) 
	{
		Vector2 velocity = new Vector2(CurrentVelocity.x, velocityY);
		RB.velocity = velocity;
	}
}
	
