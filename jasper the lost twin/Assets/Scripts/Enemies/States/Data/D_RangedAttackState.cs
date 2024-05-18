using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangeData", menuName = "Data/Enemy/Ranged attack state")]
public class D_RangedAttackState : ScriptableObject
{
	public GameObject projectile;
	public float projectileDamage;
	public float projectileSpeed;
	public float projectileTravel;
}
