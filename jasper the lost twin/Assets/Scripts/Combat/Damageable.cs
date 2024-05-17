using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
	[SerializeField]
	private float _maxHealth;
	
	public float MaxHealth	
	{	
		get
		{
			return _maxHealth;
		}
		set
		{
			_maxHealth = value;
		}
	}
	
	[SerializeField]
	private float _health = 100;
	
	[SerializeField]
	private float Health
	{
		get
		{
			return _health;
		}
		set
		{
			_health = value;
			if (_health <= 0)
			{
				isAlive = false;
			}
		}
	}
	[SerializeField]
	private bool isAlive = true;
	[SerializeField]
	private bool isInvincible = false;
	private float timeSinceHit = 0f;
	[SerializeField]
	private float invicibilityTime = 0.25f;
	
	public void Damage(DamageData damage){}
	
	public void Hit(int damage)
	{
		if (isAlive && !isInvincible)
		{
			isInvincible = true;
			Health -= damage;
		}
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if (isInvincible)
		{
			if (timeSinceHit > invicibilityTime)
			{
				isInvincible = false;
				timeSinceHit = 0;
			}
			
			timeSinceHit += Time.deltaTime;
		}
		
	}
}
