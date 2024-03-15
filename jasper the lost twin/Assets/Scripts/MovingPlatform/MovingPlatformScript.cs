using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
	public float PlatformSpeed;
	public int StartingPoint;
	public Transform[] Points;
	private int i;
    // Start is called before the first frame update
    void Start()
    {
	    transform.position = Points[StartingPoint].position;
    }

    // Update is called once per frame
    void Update()
	{
		if(Vector2.Distance(transform.position, Points[i].position) < 0.1f )
		{
			i++;
			if( i == Points.LongLength )
			{
				i = 0;
			}
		}
		
	    transform.position = Vector2.MoveTowards(transform.position, Points[i].position, PlatformSpeed * Time.deltaTime);
	}
	private void OnCollisionEnter2D ( Collision2D col )
	{
		col.transform.SetParent(transform);
	}
	private void OnCollisionExit2D (Collision2D col)
	{
		col.transform.SetParent(null);
	}
}

