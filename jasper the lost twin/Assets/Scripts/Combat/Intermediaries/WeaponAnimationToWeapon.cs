using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationToWeapon : MonoBehaviour
{
	private Weapon weapon;
	
	protected void Start()
	{
		weapon = GetComponentInParent<Weapon>();
	}
	
	private void AnimationFinishTrigger()
	{
		weapon.AnimationFinishTrigger();
	}
	
	private void AnimationActionTrigger()
	{
		weapon.AnimationActionTrigger();
	}
	
}
