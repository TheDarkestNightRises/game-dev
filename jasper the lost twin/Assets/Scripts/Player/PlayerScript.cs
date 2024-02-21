using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	#region States
	public PlayerStateMachine StateMachine { get; set; }
	public PlayerIdleState IdleState { get; set; }
	public PlayerMoveState MoveState { get; set; }
	public PlayerJumpState JumpState { get; set; }
	public PlayerInAirState InAirState { get; set; }	
	public PlayerLandState LandState { get; set; }
	#endregion

	public Animator Anim { get; set; }
	public PlayerInputHandler InputHandler { get; set; }
	public Rigidbody2D RB { get; set; }
	public Vector2 CurrentVelocity { get; set; }
	public int FacingDirection { get; set;}
	[SerializeField]
	private Transform groundCheck;
	[SerializeField]
	private PlayerData playerData;
	private BoxCollider2D myFeetCollider;
    
	public void Awake() 
	{
		StateMachine = new PlayerStateMachine();
		IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");	
		MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
		JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
		InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
		LandState = new PlayerLandState(this, StateMachine, playerData, "land");
	}
	
	public void Start()
	{
		myFeetCollider = GetComponent<BoxCollider2D>();
		Anim = GetComponent<Animator>();
		InputHandler = GetComponent<PlayerInputHandler>();
		RB = GetComponent<Rigidbody2D>();
		StateMachine.Initialize(IdleState);
		FacingDirection = 1;
	}
	
	public void Update()
	{
		CurrentVelocity = RB.velocity;
		StateMachine.CurrentState.LogicUpdate();
	}
	
	public void FixedUpdate()
	{
		StateMachine.CurrentState.PhysicsUpdate();	
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
	
	private void Flip()
	{
		FacingDirection *= -1;
		transform.Rotate(0.0f, 180.0f, 0.0f);
	}
	
	public void CheckIfShouldFlip(int xInput)
	{
	    if (xInput != 0 && xInput != FacingDirection) Flip();
	}

	public bool CheckIfTouchingGround()
	{
		return myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")); 
	}
	
	private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
	
	private void AnimationFinishedTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
}

