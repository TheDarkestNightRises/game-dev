using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	[SerializeField] float arrowSpeed = 30f;
	[SerializeField] float arrowLifeTime = 1f;
	Rigidbody2D myRigidbody;
	float xSpeed;

	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		myRigidbody.velocity = new Vector2(xSpeed, 0f);
	}

	//void OnTriggerEnter2D(Collider2D other)
	//{
		
	//}

	//void OnCollisionEnter2D(Collision2D other)
	//{
	//	Invoke(nameof(DestroyArrow), arrowLifeTime);
	//}


	//private void DestroyArrow()
	//{
	//	Destroy(gameObject);
	//}
}