using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
	private GameObject currentOneWayPlatform;
	private PlayerInputHandler playerInputHandler;
	private BoxCollider2D playerCollider;
	private CapsuleCollider2D playerCapsuleCollider;
	
	public void Start() 
	{
		playerCollider = GetComponent<BoxCollider2D>();
		playerCapsuleCollider = GetComponent<CapsuleCollider2D>();
		playerInputHandler = GetComponent<PlayerInputHandler>();
	}
	
	public void Update()
	{
		if(playerInputHandler.InputY != 0)
		{
			if(currentOneWayPlatform != null)
			{
				StartCoroutine(DisableCollision());
			}
		}
	}
    
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("OneWayPlatform"))
		{
			currentOneWayPlatform = collision.gameObject;	 
		}
	}
    
	private void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("OneWayPlatform"))
		{
			currentOneWayPlatform = null;
		}	
	}
	
	private IEnumerator DisableCollision()
	{
		BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
		Physics2D.IgnoreCollision(playerCollider, platformCollider,true);
		Physics2D.IgnoreCollision(playerCapsuleCollider, platformCollider,true);
		yield return new WaitForSeconds(1f);
		Physics2D.IgnoreCollision(playerCollider,platformCollider,false);	
		Physics2D.IgnoreCollision(playerCapsuleCollider,platformCollider,false);	

	}
}
