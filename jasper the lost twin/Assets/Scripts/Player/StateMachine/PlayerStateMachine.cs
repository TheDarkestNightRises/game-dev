using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
	public PlayerState CurrentState { get; set; }
	
	public void Initialize(PlayerState startState)
	{
		CurrentState = startState;
		CurrentState.Enter();
	}
	
	public void ChangeState(PlayerState newState)
	{
		CurrentState.Exit();
		CurrentState = newState;
		CurrentState.Enter();
	}
}
