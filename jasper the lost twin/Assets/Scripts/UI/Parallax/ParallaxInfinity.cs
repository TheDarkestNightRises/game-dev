using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxInfinity : MonoBehaviour
{
	private float length, startPos;
	private GameObject cam;
	public float parallaxEffect;
	private string cameraTag = "MainCamera";
	
	void Start()
	{
		cam = GameObject.FindWithTag(cameraTag);
		startPos = transform.position.x;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	
	void Update()
	{
		float temp = (cam.transform.position.x * (1 - parallaxEffect));
		float dist = (cam.transform.position.x * parallaxEffect);
		
		transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
		if (temp > startPos + length) startPos += length;
		else if (temp < startPos - length) startPos -= length;
		
		
	}
}
