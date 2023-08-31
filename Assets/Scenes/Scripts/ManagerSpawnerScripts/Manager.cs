using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] objectsToSpawn;

    private float countdown;
    private float nextInterval;
    private List<Spawner> activeSpawners;

    // Start is called before the first frame update
    void Start()
    {
        nextInterval = Random.Range(3f, 8f);
        countdown = 0f;
        activeSpawners = new List<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;

        if (countdown >= nextInterval)
        {
            int randomEvent = Random.Range(0, 3);

            if (randomEvent == 0)
            {
                TriggerAllSpawn();
            }
            else if (randomEvent == 1)
            {
                TriggerOnlyOddsSpawn();
            }
            else
            {
                TriggerAllSpawnThisObj();
            }

            nextInterval = Random.Range(3f, 8f);
            countdown = 0f;
        }
    }

    private void TriggerAllSpawn()
    {
        Debug.Log("All Spawn event triggered.");

        activeSpawners.Clear();

        foreach (GameObject spawnerObj in spawners)
        {
            Spawner spawner = spawnerObj.GetComponent<Spawner>();
            spawner.SetListening(true);
            spawner.Spawn();
            activeSpawners.Add(spawner);
        }

        SetInactiveSpawners();
    }

    private void TriggerOnlyOddsSpawn()
    {
        Debug.Log("Only Odds Spawn event triggered.");

        activeSpawners.Clear();

        foreach (GameObject spawnerObj in spawners)
        {
            Spawner spawner = spawnerObj.GetComponent<Spawner>();
            spawner.SetListening(true);

            if (spawner.spawnCount % 2 == 0)
            {
                spawner.Spawn();
                activeSpawners.Add(spawner);
            }
        }

        SetInactiveSpawners();
    }

    private void TriggerAllSpawnThisObj()
    {
        int randomObjIndex = Random.Range(0, objectsToSpawn.Length);
        Debug.Log("All Spawn This Obj event triggered. Object Index: " + randomObjIndex);

        activeSpawners.Clear();

        foreach (GameObject spawnerObj in spawners)
        {
            Spawner spawner = spawnerObj.GetComponent<Spawner>();
            spawner.SetListening(true);

            if (randomObjIndex < objectsToSpawn.Length)
            {
                spawner.SetObjectPrefab(objectsToSpawn[randomObjIndex]);
            }

            spawner.Spawn();
            activeSpawners.Add(spawner);
        }

        SetInactiveSpawners();
    }

    private void SetInactiveSpawners()
    {
        foreach (GameObject spawnerObj in spawners)
        {
            Spawner spawner = spawnerObj.GetComponent<Spawner>();

            if (!activeSpawners.Contains(spawner))
            {
                spawner.SetListening(false);
                spawner.SetObjectPrefab(null);
            }
        }
    }
}
