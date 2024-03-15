using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
	public float PlatformSpeed;
	public int StartingPoint;
	public Transform[] Points;
	private int currentPointIndex;
	
    void Start()
    {
	    transform.position = Points[StartingPoint].position;
    }

	void FixedUpdate()
	{
		if(Vector2.Distance(transform.position, Points[currentPointIndex].position) < 0.1f )
		{
			currentPointIndex++;
			if(currentPointIndex == Points.LongLength )
			{
				currentPointIndex = 0;
			}
		}
		
	    transform.position = Vector2.MoveTowards(transform.position, Points[currentPointIndex].position, PlatformSpeed * Time.deltaTime);
	}
	
	private void OnTriggerEnter2D(Collider2D col)
	{
		col.transform.SetParent(transform);
	}
	
	private void OnTriggerExit2D(Collider2D col)
	{
		col.transform.SetParent(null);
	}
}

