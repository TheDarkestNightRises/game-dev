//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class E2_RangedAttackState : RangedAttackState
//{
//	private Archer enemy;

//    public E2_RangedAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData, Enemy2 enemy) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
//    {
//        this.enemy = enemy;
//    }
    
//    public override void FinishAttack()
//    {
//        base.FinishAttack();
//    }

//    public override void LogicUpdate()
//    {
//        base.LogicUpdate();

//        if (isAnimationFinished)
//        {
//            if (isPlayerInMinAgroRange)
//            {
//	            stateMachine.ChangeState(enemy.PlayerDetectedState);
//            }
//            else
//            {
//	            stateMachine.ChangeState(enemy.InvestigateState);
//            }
//        }
//    }
//}
    
