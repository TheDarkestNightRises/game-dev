using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
	[SerializeField]
	public float fallDelay = 1f;
	[SerializeField]
	public float destroyDelay = 2f;
	[SerializeField]
	private Rigidbody2D rb;
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Player")) 
		{
			StartCoroutine(Fall());
		}
	}	
	private IEnumerator Fall() 
	{
		yield return WaitForSeconds(fallDelay);
		rb.bodyType = RigidbodyType2D.Dynamic;
		Destroy(gameObject, destroyDelay);
	}
	
}
  
