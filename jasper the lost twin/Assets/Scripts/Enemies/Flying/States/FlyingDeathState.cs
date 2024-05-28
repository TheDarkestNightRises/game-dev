using UnityEngine;
using System.Collections;

public class FlyingDeathState : FlyingState
{
    private Rigidbody2D rb;
	private D_FlyingEnemy stateData;
	private FlyingEnemy enemy;

    public FlyingDeathState(FlyingEnemy enemy, FlyingStateMachine stateMachine, string animBoolName,
        D_FlyingEnemy stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
	    rb = enemy.GetComponent<Rigidbody2D>();
	    this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        GameObject.Instantiate(stateData.deathVFX, enemy.transform.position, stateData.deathVFX.transform.rotation);
	    GameSession.instance.AddToScore(stateData.highScoreWorth);
	    rb.gravityScale = 1f;
	    rb.bodyType = RigidbodyType2D.Dynamic;
	    enemy.ItemDrop();
	    enemy.StartCoroutine(RemovePhysicsAfterDelay(1f));
    }
    
	private IEnumerator RemovePhysicsAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		rb.simulated = false;
	}

}