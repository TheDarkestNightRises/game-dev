using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour, IDamageable
{
	public float speed = 5f;
	public float health = 100f;
	public float damage = 10f;
	public float range = 1f;
	private GameObject player;
	public bool chase = false;
	public bool isAlive = true;
	public Transform startingPoint;
	private bool returning = false;
	private Animator anim;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!isAlive) return;
		if (player == null)
		{
			return;
		}
		if (chase)
		{
			Chase();
		}
		else if (returning)
		{
			ReturnToStart();
		}
		Flip();
	}

	private void Chase()
	{
		transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
		if (Vector2.Distance(transform.position, player.transform.position) <= range)
		{
			anim.SetTrigger("Attack");
		}
	}

	private void ReturnToStart()
	{
		transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
		if (Vector2.Distance(transform.position, startingPoint.position) <= 0.1f)
		{
			returning = false;
			Debug.Log("Returned to starting point");
		}
	}

	private void Flip()
	{
		Vector3 targetPosition;
		if (chase)
		{
			targetPosition = player.transform.position;
		}
		else if (returning)
		{
			targetPosition = startingPoint.position;
		}
		else
		{
			return;
		}

		if (transform.position.x > targetPosition.x)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
	}

	public void StartReturning()
	{
		chase = false;
		returning = true;
	}
	
	public void PerformAttack()
	{
		if (Vector2.Distance(transform.position, player.transform.position) <= range)
		{
			var damageable = player.GetComponent<IDamageable>();
			damageable.Damage(new DamageData(damage, this.gameObject));
		}
	}
	
	public void Damage(DamageData damageData)
	{
		health -= damageData.Amount;
		anim.SetTrigger("Hit");
		if (health <= 0) 
		{
			isAlive = false;
			anim.SetTrigger("Death");
		}
	}
}
