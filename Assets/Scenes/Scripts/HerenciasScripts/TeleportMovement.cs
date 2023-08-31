using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMovement : MoveableObject
{
    public float teleportInterval;
    public float teleportDistance;

    private float teleportTimer = 0f;

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (isMoving)
        {
            teleportTimer += Time.deltaTime;

            if (teleportTimer >= teleportInterval)
            {
                transform.position += transform.right * teleportDistance;
                teleportTimer = 0f;
            }
        }
    }
}