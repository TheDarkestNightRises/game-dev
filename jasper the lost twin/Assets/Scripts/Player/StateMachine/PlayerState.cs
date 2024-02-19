using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
	protected PlayerScript player;
	protected PlayerStateMachine stateMachine;
	protected PlayerData playerData;
	protected bool isAnimationFinished;
	protected float startTime;
	protected string animBoolName;
	
	public PlayerState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerDate, string animBoolName)
	{
	 this.player = player;
	 this.stateMachine = stateMachine;
	 this.playerData = playerDate;
	 this.animBoolName = animBoolName;
	}
	
	public virtual void Enter() 
	{
		Validate();	
		player.Anim.SetBool(animBoolName, true);
		startTime = Time.time;
		isAnimationFinished = false;
		Debug.Log($"State:{animBoolName}");
	}
	
	public virtual void Exit()
	{
		player.Anim.SetBool(animBoolName, false);
	}
	
	public virtual void LogicUpdate() {}
	
	public virtual void PhysicsUpdate()
	{
		Validate();	
	}
	
	public virtual void Validate() {}
	
	public virtual void AnimationTrigger() {}
	
	public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
	
}
