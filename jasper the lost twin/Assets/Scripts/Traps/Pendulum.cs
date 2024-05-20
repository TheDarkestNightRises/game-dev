using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
	Rigidbody2D rb2d;
	
	public float moveSpeed;
	public float leftAngle;
	public float rightAngle;
	
	bool movingClockwise;
	
	
    // Start is called before the first frame update
    void Start()
    {
	    rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
	    Debug.Log(transform.rotation.z);
	    rb2d.angularVelocity = moveSpeed;
	    
    }
}
