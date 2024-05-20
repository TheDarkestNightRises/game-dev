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
	public float stunTime = 0.65f;
	public LayerMask whatIsPlayer;
}
