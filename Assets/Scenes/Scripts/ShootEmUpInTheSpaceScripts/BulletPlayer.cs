using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public GameObject respawnPoint1;
    public GameObject enemy1;
    public GameObject respawnPoint2;
    public GameObject enemy2;
    public GameObject respawnPoint3;
    public GameObject megaEnemy1;
    public GameObject respawnPoint4;
    public GameObject megaEnemy2;

    [SerializeField] private AudioSource enExplosionSoundEffect;
    [SerializeField] private ParticleSystem explosionParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy1.transform.position = respawnPoint1.transform.position;
            PlaySoundAndParticlesAndDestroy();
            ScoreRegister.Instance.AddScore(10);
        }
        if (other.gameObject.CompareTag("Enemy1"))
        {
            enemy2.transform.position = respawnPoint2.transform.position;
            PlaySoundAndParticlesAndDestroy();
            ScoreRegister.Instance.AddScore(10);
        }
        if (other.gameObject.CompareTag("MegaEnemy"))
        {
            megaEnemy1.transform.position = respawnPoint3.transform.position;
            PlaySoundAndParticlesAndDestroy();
            ScoreRegister.Instance.AddScore(20);
        }
        if (other.gameObject.CompareTag("MegaEnemy1"))
        {
            megaEnemy2.transform.position = respawnPoint4.transform.position;
            PlaySoundAndParticlesAndDestroy();
            ScoreRegister.Instance.AddScore(20);
        }
    }

    private void PlaySoundAndParticlesAndDestroy()
    {
        if (enExplosionSoundEffect != null)
        {
            enExplosionSoundEffect.Play();
            explosionParticles.transform.position = transform.position;
            explosionParticles.Play();
            StartCoroutine(DestroyWithDelay(gameObject, 0.150f));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyWithDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}