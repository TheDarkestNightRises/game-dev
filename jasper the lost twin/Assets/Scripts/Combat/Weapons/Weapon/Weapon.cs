using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Weapon : MonoBehaviour
{
	protected Animator baseAnimator;
	protected Animator weaponAnimator;
	private CinemachineImpulseSource impulseCamera;
	
	protected PlayerAttackState attackState;
	protected int attackCounter;
	
	protected virtual void Start()
	{
		baseAnimator = transform.Find("Base").GetComponent<Animator>();
		weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
		impulseCamera = GetComponent<CinemachineImpulseSource>();
	}
	
	public virtual void EnterWeapon()
	{
		baseAnimator.SetBool("attack", true);
		weaponAnimator.SetBool("attack", true);
		
		if (attackCounter >= 3) attackCounter = 0;
		
		baseAnimator.SetInteger("attackCounter", attackCounter);
		weaponAnimator.SetInteger("attackCounter", attackCounter);	
	}
	
	public virtual void ExitWeapon()
	{
		baseAnimator.SetBool("attack", false);
		weaponAnimator.SetBool("attack", false);	
			
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
