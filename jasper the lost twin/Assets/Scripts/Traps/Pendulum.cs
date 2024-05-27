﻿using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;

    bool movingClockwise;

    [SerializeField] public float damage = 30f;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movingClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void ChangeMoveDir()
    {
        if (transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }

        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }

    public void Move()
    {
        ChangeMoveDir();
        if (movingClockwise)
        {
            rb2d.angularVelocity = moveSpeed;
        }

        if (!movingClockwise)
        {
            rb2d.angularVelocity = -1 * moveSpeed;
        }
    }

    // Sent when another object enters a trigger collider attached to this object (2D physics only).
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var damageble = other.GetComponent<IDamageable>();
            var damageData = new DamageData(damage, this.gameObject);
            damageble.Damage(damageData);
        }
    }
}