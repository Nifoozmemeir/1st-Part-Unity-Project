using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MegamanController : MonoBehaviour
{
    public Transform myTransform;
    public float speed;
    public float speedRotation;
    public Vector2 movementLimits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -speedRotation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myTransform.Rotate(Vector3.up, speedRotation * Time.deltaTime);
        }

        Vector3 newPosition = transform.position;

        newPosition.x = Mathf.Clamp(newPosition.x, -movementLimits.x, movementLimits.x);
        newPosition.z = Mathf.Clamp(newPosition.z, -movementLimits.y, movementLimits.y);

        transform.position = newPosition;
    }
}
