using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : State
{
	protected D_HitState stateData;
	
	public HitState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_HitState stateData) : base(etity, stateMachine, animBoolName)
	{
		this.stateData = stateData;
	}
	
}
