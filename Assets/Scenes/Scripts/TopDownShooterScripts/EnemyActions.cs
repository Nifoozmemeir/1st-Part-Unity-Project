using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyActions : MonoBehaviour
{
    public GameObject MegaEnemy;
    public float spawnInterval;
    public int maxEnemies;

    private List<Vector3> enemySpawnPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateSpawnPositions();
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateSpawnPositions()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            Vector3 randomPosition = Random.onUnitSphere * 10f;
            randomPosition.y = 2.99f;
            enemySpawnPositions.Add(randomPosition);
        }
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject enemyInstance = Instantiate(MegaEnemy, spawnPosition, Quaternion.identity);

            if (enemyInstance != null)
            {
                enemySpawnPositions.Remove(spawnPosition);
            }
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        int randomIndex = Random.Range(0, enemySpawnPositions.Count);
        Vector3 spawnPosition = enemySpawnPositions[randomIndex];
        return spawnPosition;
    }
}
