using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    public Transform myTransform;
    public Transform bulletShoot;
    public float speed;
    public float bulletSpeed;
    public Vector2 movementLimits;
    public GameObject bulletPrefab;
    public float bulletLife;
    public float fireRate;
    private float nextFireTime = 0f;
    [SerializeField] private AudioSource shootSoundEffect;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= nextFireTime)
            {
                shootSoundEffect.Play();

                var bullet = Instantiate(bulletPrefab, bulletShoot.position, bulletShoot.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletShoot.forward * bulletSpeed;
                bullet.transform.eulerAngles = new Vector3(90f, bullet.transform.eulerAngles.y, bullet.transform.eulerAngles.z);

                Destroy(bullet, bulletLife);

                nextFireTime = Time.time + fireRate;
            }
        }

        Vector3 newPosition = transform.position;

        newPosition.x = Mathf.Clamp(newPosition.x, -movementLimits.x, movementLimits.x);
        newPosition.z = Mathf.Clamp(newPosition.z, -movementLimits.y, movementLimits.y);

        transform.position = newPosition;
    }
}