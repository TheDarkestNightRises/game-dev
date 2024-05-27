public class Swordsman_DeathState : DeadState
{
    private Swordsman _enemy;
    private D_DeadState _stateData;

    public Swordsman_DeathState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,
        D_DeadState stateData, Swordsman enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        _enemy = enemy;
        _stateData = stateData;
    }
}