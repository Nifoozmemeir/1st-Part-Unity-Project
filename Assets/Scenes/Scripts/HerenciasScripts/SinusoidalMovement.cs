using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMovement : MoveableObject
{
    public float speed;
    public float amplitude;
    public float frequency;
    private float startTime;
    private Rigidbody rigidbody;

    private void Start()
    {
        startTime = Time.time;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        if (isMoving)
        {
            float yOffset = Mathf.Sin((Time.time - startTime) * frequency) * amplitude;
            Vector3 verticalMovement = Vector3.up * yOffset * speed;
            Vector3 forwardMovement = transform.right * speed;

            rigidbody.velocity = verticalMovement + forwardMovement;
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}