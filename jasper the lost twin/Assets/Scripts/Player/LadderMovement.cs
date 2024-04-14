using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LadderMovement : MonoBehaviour
{
	private float vertical;
	private float speed = 8f;
	private bool isLadder;
	private bool isClimbing;
	
	[SerializeField] private Rigidbody2D rb;

   
	void Update()
	{
		vertical = Input.GetAxis("Vertical");
	    
		if(isLadder && Mathf.Abs(vertical)>0)
		{
			isClimbing = true;
		}
	}
    
	private void FixedUpdate()
	{
		if(isClimbing)
		{
			rb.gravityScale = 0f;
			rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
		}
		else
		{
			rb.gravityScale =4f;
		}
	}
    
    
	private void onTriggerEnter2D(CapsuleCollider2D collision)
	{
		if(collision.CompareTag("Climbing"))
		{
			isLadder = true;
		}
		
	}
	
	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("Climbing"))
		{
			isLadder = false;
			isClimbing = false;
		}
		
	}
}
