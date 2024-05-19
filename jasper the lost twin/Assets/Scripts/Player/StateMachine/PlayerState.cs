﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
	protected PlayerScript player;
	protected PlayerStateMachine stateMachine;
	protected PlayerData playerData;
	protected bool isAnimationFinished;
	
	protected float startTime;
	
	private string animBoolName;
	
	public PlayerState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
	{
		this.player = player;
		this.stateMachine = stateMachine;
		this.playerData = playerData;
		this.animBoolName = animBoolName;
	}
	
	public virtual void Enter()
	{
		DoChecks();
		player.Anim.SetBool(animBoolName, true);
		Debug.Log($"Player state: {animBoolName}");
		startTime = Time.time;
		isAnimationFinished = false;
	}
	
	public virtual void Exit()
	{
		player.Anim.SetBool(animBoolName, false);
	}
	
	public virtual void LogicUpdate()
	{
		
	}
	
	public virtual void PhysicsUpdate()
	{
		DoChecks();
	}
	
	public virtual void DoChecks() {}
	
	public virtual void AnimationTrigger() {}
	
	public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
