using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MoveableObject
{
    public float speed;

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}