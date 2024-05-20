using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingHitState : FlyingState
{
	public FlyingHitState(FlyingEnemy enemy, FlyingStateMachine stateMachine, string animBoolName, D_FlyingEnemy stateData) : base(enemy, stateMachine, animBoolName)
	{
		
	}
}
