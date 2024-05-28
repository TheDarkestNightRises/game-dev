using UnityEngine;
using Cinemachine;

public class Weapon : MonoBehaviour
{
    protected Animator baseAnimator;
    private CinemachineImpulseSource impulseCamera;

    protected PlayerAttackState attackState;
    protected int attackCounter;

    protected virtual void Start()
    {
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        impulseCamera = GetComponent<CinemachineImpulseSource>();
    }

    public virtual void EnterWeapon()
    {
        baseAnimator.SetBool("attack", true);

        if (attackCounter >= 3) attackCounter = 0;

        baseAnimator.SetInteger("attackCounter", attackCounter);
    }

    public virtual void ExitWeapon()
    {
        baseAnimator.SetBool("attack", false);

        attackCounter++;
    }

    public virtual void AnimationFinishTrigger()
    {
        attackState.AnimationFinishTrigger();
    }

    public virtual void AnimationActionTrigger()
    {
    }

    public void InitWeapon(PlayerAttackState attackState)
    {
        this.attackState = attackState;
    }

    public void GenerateImpulse(float power)
    {
        impulseCamera.GenerateImpulse(power);
    }
}