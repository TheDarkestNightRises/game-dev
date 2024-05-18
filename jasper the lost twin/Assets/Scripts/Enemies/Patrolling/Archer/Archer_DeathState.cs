using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_DeathState : DeadState
{
	private Archer enemy;

	public Archer_DeathState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Archer enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }
}
    
