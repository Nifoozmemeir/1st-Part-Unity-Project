using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletLifetime;
    private float bulletSpeed;
    private Vector3 bulletDirection;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletDirection * bulletSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        bulletDirection = direction.normalized;
    }

    public void SetSpeed(float speed)
    {
        bulletSpeed = speed;
    }
}
