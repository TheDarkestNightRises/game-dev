using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isFollowing;
    public float followSpeed;
    public Transform followTarget;
    // Start is called before the first frame update
    void Start()
    {
        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
        }
    }
}
