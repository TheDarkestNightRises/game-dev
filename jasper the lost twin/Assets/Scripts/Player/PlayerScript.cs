using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	#region States
	public PlayerStateMachine StateMachine { get; set; }
	public PlayerIdleState IdleState { get; set; }
	public PlayerMoveState MoveState { get; set; }
	#endregion

	public Animator Anim { get; set; }
	public PlayerInputHandler InputHandler { get; set; }
	public Rigidbody2D RB { get; set; }
	public Vector2 CurrentVelocity { get; set; }
	[SerializeField]
	private PlayerData PlayerData;
    
	public void Awake() 
	{
		StateMachine = new PlayerStateMachine();
		IdleState = new PlayerIdleState(this, StateMachine, PlayerData, "idle");	
		MoveState = new PlayerMoveState(this, StateMachine, PlayerData, "move");
	}
	
	public void Start()
	{
		Anim = GetComponent<Animator>();
		InputHandler = GetComponent<PlayerInputHandler>();
		RB = GetComponent<Rigidbody2D>();
		StateMachine.Initialize(IdleState);
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
	
}

