using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Enemy/Entity state")]
public class D_Entity : ScriptableObject
{
	public float maxHealth = 30f;
	public float damageHopVelocity = 3f;
	public float wallCheckRange = 0.2f;
	public float ledgeCheckRange = 0.4f;
	public float minAggroDistance = 3f;
	public float maxAggroDistance = 3f;
	public float meleeAttackRange = 1f;
	public LayerMask whatIsGround;
	public LayerMask whatIsPlayer;
}
