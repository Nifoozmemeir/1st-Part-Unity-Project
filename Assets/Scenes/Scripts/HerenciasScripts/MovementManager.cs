using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public MoveableObject[] moveableObjects;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (MoveableObject moveableObject in moveableObjects)
            {
                moveableObject.StartMoving();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (MoveableObject moveableObject in moveableObjects)
            {
                moveableObject.StopMoving();
            }
        }
    }
}