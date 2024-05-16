using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
	[SerializeField]
	private float _maxHealth;
	
	public void Damage(DamageData damage){}
}
