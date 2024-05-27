using UnityEngine;

public class Swordsman : Entity
{
    public Swordsman_IdleState IdleState { get; set; }
    public Swordsman_MoveState MoveState { get; set; }
    public Swordsman_PlayerDetectedState PlayerDetectedState { get; set; }
    public Swordman_PursueState PursueState { get; set; }
    public Swordsman_InvestigateState InvestigateState { get; set; }
    public Swordsman_MeleeAttackState MeleeAttackState { get; set; }
    public Swordsman_DeathState DeathState { get; set; }
    public Swordsman_HitState HitState { get; set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetected playerDetectedData;
    [SerializeField] private D_PursueState pursueData;
    [SerializeField] private D_InvestigateState investigateData;
    [SerializeField] private D_MeleeAttack meleeAttackData;
    [SerializeField] private D_DeadState deathStateData;
    [SerializeField] private D_HitState hitStateData;
    [SerializeField] private Transform meleeAttackPosition;

    protected override void Awake()
    {
        base.Awake();
        MoveState = new Swordsman_MoveState(this, stateMachine, "move", moveStateData, this);
        IdleState = new Swordsman_IdleState(this, stateMachine, "idle", idleStateData, this);
        PlayerDetectedState =
            new Swordsman_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        PursueState = new Swordman_PursueState(this, stateMachine, "pursue", pursueData, this);
        InvestigateState = new Swordsman_InvestigateState(this, stateMachine, "investigate", investigateData, this);
        MeleeAttackState = new Swordsman_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition,
            meleeAttackData, this);
        DeathState = new Swordsman_DeathState(this, stateMachine, "death", deathStateData, this);
        HitState = new Swordsman_HitState(this, stateMachine, "hit", hitStateData, this);
    }

    public override void Start()
    {
        stateMachine.Initialize(MoveState);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackData.attackRadius);
    }

    public void SendTriggerAttack()
    {
        MeleeAttackState.TriggerAttack();
    }

    public void SendFinishAttack()
    {
        MeleeAttackState.FinishAttack();
    }

    public override void Damage(DamageData damageData)
    {
        if (stateMachine.CurrentState == HitState)
        {
            return;
        }

        if (!isAlive)
        {
            return;
        }

        if (currentHealth <= 0)
        {
            isAlive = false;
            stateMachine.ChangeState(DeathState);
            return;
        }

        base.Damage(damageData);
        stateMachine.ChangeState(HitState);
    }
}