using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
	[SerializeField] public float damage;
   
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))			
		{
			var damageData = new DamageData(damage, gameObject);
			other.GetComponent<IDamageable>().Damage(damageData);
		}
	}
}
