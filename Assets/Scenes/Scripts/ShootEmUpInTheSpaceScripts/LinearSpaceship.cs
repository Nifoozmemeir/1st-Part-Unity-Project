using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinearSpaceship : MonoBehaviour
{
    public float speed;
    public Transform bulletShoot;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletLife;
    public float fireRate;
    private float nextFireTime = 0f;

    public GameObject respawnPoint;
    public GameObject player;

    public GameObject respawnPoint1;
    public GameObject enemy;

    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource pyExplosionSoundEffect;

    [SerializeField] private ParticleSystem explosionParticles;

    private void FixedUpdate()
    {
        Vector3 movement = Vector3.forward * speed * Time.fixedDeltaTime;
        transform.Translate(movement);

        if (Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void FireBullet()
    {
        shootSoundEffect.Play();

        var bullet = Instantiate(bulletPrefab, bulletShoot.position, bulletShoot.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletShoot.forward * bulletSpeed;
        bullet.transform.eulerAngles = new Vector3(90f, bullet.transform.eulerAngles.y, bullet.transform.eulerAngles.z);

        Destroy(bullet, bulletLife);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pyExplosionSoundEffect.Play();
            explosionParticles.transform.position = transform.position;
            explosionParticles.Play();

            LifeCount playerHealth = other.gameObject.GetComponent<LifeCount>();
            if (playerHealth != null)
            {
                playerHealth.DecreaseLife();
            }

            player.transform.position = respawnPoint.transform.position;
        }
        if (other.gameObject.CompareTag("LimitLine"))
        {
            enemy.transform.position = respawnPoint1.transform.position;
        }
    }
}