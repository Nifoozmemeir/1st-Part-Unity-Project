using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject player;

    [SerializeField] private AudioSource pyExplosionSoundEffect;
    [SerializeField] private ParticleSystem explosionParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LifeCount playerHealth = other.gameObject.GetComponent<LifeCount>();
            if (playerHealth != null)
            {
                playerHealth.DecreaseLife();
            }

            player.transform.position = respawnPoint.transform.position;

            PlaySoundAndParticlesAndDestroy();
        }
    }

    private void PlaySoundAndParticlesAndDestroy()
    {
        if (pyExplosionSoundEffect != null)
        {
            pyExplosionSoundEffect.Play();
            explosionParticles.transform.position = transform.position;
            explosionParticles.Play();
            StartCoroutine(DestroyWithDelay(gameObject, Mathf.Max(pyExplosionSoundEffect.clip.length, explosionParticles.main.duration)));
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
