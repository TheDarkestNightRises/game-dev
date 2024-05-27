using UnityEngine;

public class FallTrigger : MonoBehaviour
{
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			var player = other.GetComponent<PlayerScript>();
			player.Die();
			player.RB.gravityScale = 0.2f;
		}
	}
}
