using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	public int healthRestore = 20;

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			PlayerScript playerscript = collision.GetComponent<PlayerScript>();
			playerscript.Heal(healthRestore);
			Destroy(gameObject);
		}
	}
}
