using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Parallax : MonoBehaviour
{
	private float length;
	private float startPos;
	private string cameraTag = "MainCamera";
	public float parallaxEffect;
	private GameObject camera;
	
    void Start()
    {
	    camera = GameObject.FindWithTag(cameraTag);
	    startPos =	transform.position.x;
	    length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
	    float distance = camera.transform.position.x * parallaxEffect;
	    transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
