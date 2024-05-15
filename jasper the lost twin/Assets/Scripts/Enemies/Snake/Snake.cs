using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
	public float moveSpeed;
	public GameObject[] wayPoints;
	
	int nextWayPoint = 1;
	float distToPoint;
	
	void Update()
	{
		Move();
	}
	
	// Update is called once per frame
	void Move()
    {
	    distToPoint= Vector2.Distance(transform.position, wayPoints[nextWayPoint].transform.position);
	    
	    transform.position= Vector2.MoveTowards(transform.position, wayPoints[nextWayPoint].transform.position,
		    moveSpeed* Time.deltaTime);
		    
	    if(distToPoint <0.2f)
	    {
	    	TakeTurn();
	    }
    }
    
	void TakeTurn()
	{
		Vector3 currRot = transform.eulerAngles;
		currRot.z += wayPoints[nextWayPoint].transform.eulerAngles.z;
		transform.eulerAngles= currRot;
		ChooseNextWayPoint();
	}
	
	void ChooseNextWayPoint()
	{
		nextWayPoint++;
		
		if(nextWayPoint == wayPoints.Length)
		{
			nextWayPoint = 0;
		}
	}
}
