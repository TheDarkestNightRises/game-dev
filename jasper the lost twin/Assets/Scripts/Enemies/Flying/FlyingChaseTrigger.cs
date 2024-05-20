using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingChaseTrigger : MonoBehaviour
{
	public FlyingEnemy[] enemyArray;
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			foreach(FlyingEnemy enemy in enemyArray)
			{
				enemy.Chase = true;
			}
		}
	}
	
	protected void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			foreach(FlyingEnemy enemy in enemyArray)
			{
				enemy.Returning = true;
				enemy.Chase = false;
			}
		}
	}
}
