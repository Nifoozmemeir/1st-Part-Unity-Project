using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMovement : MoveableObject
{
    public float speed;
    public float zigzagFrequency;
    public float zigzagAmplitude;
    private Rigidbody rigidbody;
    private float timer;

    private void Start()
    {
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
            Vector3 forwardMovement = transform.right * speed;
            rigidbody.velocity = forwardMovement;

            float zigzagOffset = Mathf.Sin(timer * zigzagFrequency) * zigzagAmplitude;
            Vector3 zigzagMovement = transform.forward * zigzagOffset;
            rigidbody.AddForce(zigzagMovement, ForceMode.VelocityChange);

            timer += Time.fixedDeltaTime;
        }
    }
}