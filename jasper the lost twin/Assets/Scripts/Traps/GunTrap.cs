using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTrap : MonoBehaviour
{
	[SerializeField] public float attackCooldown;
	[SerializeField] public Transform firePoint;
	[SerializeField] public GameObject[] fireballs;
	private float cooldownTimer;
	
	private void Attack()
	{
		cooldownTimer = 0;
		
		fireballs[FindFireball()].transform.position = firePoint.position;
		//fireballs[FindFireball()].GetComponent<EnemyProjectile>().SetDirection(Mathf.Sign(transform.localScale.x));
	}
	
	private int FindFireball()
	{
		for(int i = 0; i < fireballs.Length; i++ )
		{
			if(!fireballs[i].activeInHierarchy)
				return i;
		}
		return 0;
	}
	
	private void Update()
	{
		cooldownTimer += Time.deltaTime;
		if(cooldownTimer >= attackCooldown )
		{
			Attack();
		}
	}	
}
