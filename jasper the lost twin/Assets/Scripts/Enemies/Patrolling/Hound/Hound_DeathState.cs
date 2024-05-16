﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound_DeathState : DeadState
{
	private Hound enemy;
	public Hound_DeathState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Hound enemy) : base(entity, stateMachine, animBoolName, stateData)
	{
		this.enemy = enemy;
	}
}
