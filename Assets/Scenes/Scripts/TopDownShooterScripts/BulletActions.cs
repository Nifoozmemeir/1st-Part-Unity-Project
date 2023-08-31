using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletActions : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootTransform;
    public float bulletSpeed;
    public float fireRate;
    private float nextFireTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootTransform.position, shootTransform.rotation);
        BulletMovement bulletController = bullet.GetComponent<BulletMovement>();
        bulletController.SetDirection(-transform.up);
        bulletController.SetSpeed(bulletSpeed);
    }
}
