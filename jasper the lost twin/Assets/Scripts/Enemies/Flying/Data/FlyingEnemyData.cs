using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newFlyingData", menuName = "Data/Enemy/Flying data")]
public class D_FlyingEnemy : ScriptableObject
{
	public float maxHealth = 30f;
	public float damage = 10f;
	public float flightSpeed = 4f;
	public float range = 4f;
	public float damageHopVelocity = 10f;
	public float wallCheckRange = 0.2f;
	public float ledgeCheckRange = 0.4f;
	public float minAggroDistance = 3f;
	public float maxAggroDistance = 3f;
	public float meleeAttackRange = 1f;
	public LayerMask whatIsGround;
	public LayerMask whatIsPlayer;
}
