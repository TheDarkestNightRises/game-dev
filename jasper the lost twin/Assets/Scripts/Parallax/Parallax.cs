using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	private float length;
	private float startPos;
	private string cameraTag = "MainCamera";
	public float parallaxEffect;
	private Camera camera;
	
    void Start()
    {
	    GameObject cameraObject = GameObject.FindWithTag(cameraTag);
	    camera = cameraObject.GetComponent<Camera>();
	    startPos =	transform.position.x;
	    length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
	    float distance = camera.transform.position.x * parallaxEffect;
	    transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
