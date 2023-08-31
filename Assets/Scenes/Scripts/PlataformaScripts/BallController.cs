using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Transform myTransform;
    public float speed = 5f;
    private int collisionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myTransform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myTransform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            myTransform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            myTransform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.KeypadPlus) || Input.GetKey(KeyCode.Plus))
        {
            myTransform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.KeypadMinus) || Input.GetKey(KeyCode.Minus))
        {
            myTransform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("InvisibleWall"))
        {
            Debug.Log("La pelota está en " + myTransform.position.ToString() + ". No hay a donde ir en esa dirección.");

            collisionCount++;
            if (collisionCount >= 5)
            {
                Debug.Log("Gorgoniaa...");
            }
        }
    }
}