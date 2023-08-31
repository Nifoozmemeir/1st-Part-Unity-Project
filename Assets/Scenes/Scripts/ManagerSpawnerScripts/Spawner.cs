using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int maxObjects;

    [HideInInspector]
    public int spawnCount = 0;

    private bool isListening = true;
    public GameObject objectPrefab;
    public GameObject[] objectsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObjectPrefab(GameObject prefab)
    {
        objectPrefab = prefab;
    }

    public void Spawn()
    {
        if (!isListening || spawnCount >= maxObjects)
            return;

        GameObject spawnedObject;

        if (objectPrefab != null)
        {
            spawnedObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            spawnedObject = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], transform.position, Quaternion.identity);
        }

        spawnedObject.GetComponent<Rigidbody>().velocity = transform.forward * 5f;

        Destroy(spawnedObject, 5f);
        spawnCount++;
    }

    public void SetListening(bool listening)
    {
        isListening = listening;
    }
}
