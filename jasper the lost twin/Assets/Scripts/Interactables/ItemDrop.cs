using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
	private Rigidbody2D itemRB;
	public float dropForce = 5;
	bool isCollected = false;
	
    // Start is called before the first frame update
    void Start()
    {
	    itemRB = GetComponent<Rigidbody2D>();
	    itemRB.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }

	protected void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player" && !isCollected)
		{
			isCollected = true;
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}

}
