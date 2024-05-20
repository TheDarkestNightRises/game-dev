using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDeathState : FlyingState
{
	private Rigidbody2D rb;
	private bool isFalling = false;

	public FlyingDeathState(FlyingEnemy enemy, FlyingStateMachine stateMachine, string animBoolName, D_FlyingEnemy stateData) : base(enemy, stateMachine, animBoolName)
	{
		rb = enemy.GetComponent<Rigidbody2D>();
		if (rb == null)
		{
			Debug.LogError("Rigidbody2D component not found on the FlyingEnemy.");
		}
	}

	public override void Enter()
	{
		base.Enter();
		if (rb != null)
		{
			rb.gravityScale = 1f;
			rb.bodyType = RigidbodyType2D.Dynamic;
			isFalling = true;
		}
	}
}
