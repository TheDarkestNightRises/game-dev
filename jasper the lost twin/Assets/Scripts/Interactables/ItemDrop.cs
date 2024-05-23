using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
	private Rigidbody2D itemRB;
	public float dropForce = 5;
	[SerializeField] int pointsForCoinPickup = 1;
	bool isCollected = false;
	bool wasCollected = false;

	void Start()
    {
	    itemRB = GetComponent<Rigidbody2D>();
	    itemRB.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }

	protected void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player" && !isCollected)
		{
			wasCollected = true;
			FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
			isCollected = true;
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}

}
