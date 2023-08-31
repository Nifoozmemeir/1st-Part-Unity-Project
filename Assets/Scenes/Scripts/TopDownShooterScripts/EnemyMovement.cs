using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float Speed;
    public LayerMask bulletLayer;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bulletLayer == (bulletLayer | (1 << other.gameObject.layer)))
        {
            DestroyEnemy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DestroyPlayer(collision.gameObject);
        }
    }

    public void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }

    public void DestroyPlayer(GameObject player)
    {
        Destroy(player);
        Debug.Log("GAME OVER, te destruyeron :(");
        Time.timeScale = 0f;
    }
}
