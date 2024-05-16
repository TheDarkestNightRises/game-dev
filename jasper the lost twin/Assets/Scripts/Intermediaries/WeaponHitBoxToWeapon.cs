using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitBoxToWeapon : MonoBehaviour
{
	private AggresiveWeapon weapon;
	
	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		weapon = GetComponentInParent<AggresiveWeapon>();
	}
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		weapon.AddToDetected(other);
	}
	
	// Sent when another object leaves a trigger collider attached to this object (2D physics only).
	protected void OnTriggerExit2D(Collider2D other)
	{
		weapon.RemoveFromDetected(other);
	}
}
