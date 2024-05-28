using UnityEngine;

public class FlyingDeathState : FlyingState
{
    private Rigidbody2D rb;
    private D_FlyingEnemy stateData;

    public FlyingDeathState(FlyingEnemy enemy, FlyingStateMachine stateMachine, string animBoolName,
        D_FlyingEnemy stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
        rb = enemy.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the FlyingEnemy.");
        }
    }

    public override void Enter()
    {
        base.Enter();
        GameObject.Instantiate(stateData.deathVFX, enemy.transform.position, stateData.deathVFX.transform.rotation);

        if (rb != null)
        {
            rb.gravityScale = 1f;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}