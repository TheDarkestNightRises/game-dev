using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingStateMachine 
{
	public FlyingState CurrentState { get; private set; }

	public void Initialize(FlyingState startState)
	{
		CurrentState = startState;
		CurrentState.Enter();
	}

	public void ChangeState(FlyingState newState)
	{
		CurrentState.Exit();
		CurrentState = newState;
		CurrentState.Enter();
	}
}
