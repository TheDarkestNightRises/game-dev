using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDeathState : FlyingState
{
	public FlyingDeathState(FlyingEnemy enemy, FlyingStateMachine stateMachine, string animBoolName, D_FlyingEnemy stateData) : base(enemy, stateMachine, animBoolName)
	{
		
	}
}
