using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	#region States
	public PlayerStateMachine StateMachine { get; private set; }
	public PlayerIdleState IdleState { get; set; }
	public PlayerMoveState MoveState { get; set; }
	public PlayerJumpState JumpState { get; set; }
	public PlayerInAirState InAirState { get; set; }	
	public PlayerLandState LandState { get; set; }
	#endregion

	#region Player Components
	public Animator Anim { get; private set; }	
	public PlayerInputHandler InputHandler { get; set; }
	
	[SerializeField]
	private PlayerData playerData;
	public Rigidbody2D RB { get; set; }
	private BoxCollider2D myFeetCollider;
	#endregion
	
	public Vector2 CurrentVelocity { get; set; }
	public int FacingDirection { get; set; }
	private Vector2 workspace;

	public void Awake()
	{
		StateMachine = new PlayerStateMachine();
		IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
		MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
		JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
		InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
		LandState = new PlayerLandState(this, StateMachine, playerData, "land");
	}
	
	private void Start()
	{
		myFeetCollider = GetComponent<BoxCollider2D>();
		Anim = GetComponent<Animator>();
		InputHandler = GetComponent<PlayerInputHandler>();
		RB = GetComponent<Rigidbody2D>();
		FacingDirection = 1;
		StateMachine.Initialize(IdleState);
	}
	
	private void Update()
	{
		CurrentVelocity = RB.velocity;
		StateMachine.CurrentState.LogicUpdate();
	}
	
	private void FixedUpdate()
	{
		StateMachine.CurrentState.PhysicsUpdate();
	}
	
	public void SetVelocityX(float velocity)
	{
		workspace.Set(velocity, CurrentVelocity.y);
		RB.velocity = workspace;
		CurrentVelocity = workspace;
	}
	
	public void SetVelocityY(float velocity)
	{
		workspace.Set(CurrentVelocity.x, velocity);
		RB.velocity = workspace;
		CurrentVelocity = workspace;
	}
	
	public void Flip()
	{
		FacingDirection *= -1;
		transform.Rotate(0.0f, 180.0f, 0.0f);
	}
	
	public void CheckIfShouldFlip(int xInput)
	{
		if (xInput != 0 && xInput != FacingDirection)
		{
			Flip();
		}
	}
	
	public bool CheckIfTouchingGround()
	{
		return myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")); 
	}
	
	private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
	
	private void AnimationFinishedTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
}
