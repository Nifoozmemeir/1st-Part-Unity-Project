using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigzagSpaceship : MonoBehaviour
{
    public float speed;
    public float zigzagFrequency;
    public float zigzagAmplitude;
    public Transform bulletShoot;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletLife;
    public float fireRate;
    private float nextFireTime = 0f;

    private Rigidbody rigidbody;
    private float timer;

    public GameObject respawnPoint;
    public GameObject player;

    public GameObject respawnPoint1;
    public GameObject enemy;

    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource pyExplosionSoundEffect;

    [SerializeField] private ParticleSystem explosionParticles;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMovement = transform.forward * speed;
        rigidbody.velocity = forwardMovement;

        float zigzagOffset = Mathf.Sin(timer * zigzagFrequency) * zigzagAmplitude;
        Vector3 zigzagMovement = transform.right * zigzagOffset;
        rigidbody.AddForce(zigzagMovement, ForceMode.VelocityChange);

        timer += Time.fixedDeltaTime;

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