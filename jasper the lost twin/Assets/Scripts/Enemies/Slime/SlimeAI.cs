using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
	[SerializeField] 
	public float moveSpeed = 1f;
	private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
	    RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
	    RB.velocity = new Vector2(moveSpeed, 0f);
    }
    
	// Sent when another object leaves a trigger collider attached to this object (2D physics only).
	protected void OnTriggerExit2D(Collider2D other)
	{
		moveSpeed = -moveSpeed;
		FlipSprite();
	}
	
	private void FlipSprite()
	{
		transform.localScale = new Vector2(-(Mathf.Sign(RB.velocity.x)), 1f);
	}
	
}
