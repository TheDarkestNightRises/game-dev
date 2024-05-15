using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeData", menuName = "Data/Enemy/Melee Attack state")]
public class D_MeleeAttack : ScriptableObject
{	
	public float attackRadius = 5;
	public float attackDamage = 10f;
	public LayerMask whatIsPlayer;
}
