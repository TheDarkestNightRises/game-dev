using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BirdAI : MonoBehaviour
{	
	public float speed = 200f;
	public float nextWaypointDistance = 3f;
	private int currentWayPoint = 0;
	private Path path;
	private bool reachedEndOfPath = false;
	private Seeker seeker;
	private SpriteRenderer sprite;
	private Rigidbody2D RB;
	private Transform target;

	protected void Start()
	{
		seeker = GetComponent<Seeker>();
		RB = GetComponent<Rigidbody2D>();
		target = GameObject.FindWithTag("Player").transform;
		InvokeRepeating("UpdatePath", 0f, .5f);
	}
	
	public void UpdatePath()
	{
		if (!seeker.IsDone()) return;
		seeker.StartPath(RB.position, target.position, OnPathComplete);
	}
	
	public void OnPathComplete(Path p)
	{
		if (!p.error) 
		{
			path = p;
			currentWayPoint = 0;
		}
	}
	
	protected void Update()
	{
		if (path == null) return;
		
		if (currentWayPoint >= path.vectorPath.Count)
		{
			reachedEndOfPath = true;
			return;
		}
		else
		{
			reachedEndOfPath = false;
		}
		
		Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - RB.position).normalized;
		Vector2 force = direction * speed * Time.deltaTime;
		RB.AddForce(force);
		
		float distance = Vector2.Distance(RB.position, path.vectorPath[currentWayPoint]);
		
		if (distance < nextWaypointDistance)
		{
			currentWayPoint++;
		}
			
		FlipSprite();
	}
	
	public void FlipSprite()
	{
		if (RB.velocity.x >= 0.1f)
		{
			transform.localScale = new Vector3(-1f,1f,1f);
		}
		else if (RB.velocity.x <= -0.01f)
		{
			transform.localScale = new Vector3(1f,1f,1f);
		}
	}
}
