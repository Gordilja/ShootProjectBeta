using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabObst;
    private int spawnCount;
    public int maxSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        //spawnCount = FindObjectOfType<SaveData>().score + 1;
        InvokeRepeating("SpawnObstacle", 2, 1.4f);
        maxSpawn = 10;
    }
    private void Update()
    {
        spawnCount = FindObjectOfType<SaveData>().score + 1;
    }

    void SpawnObstacle() 
    {
        /*
        for (spawnCount = 0; spawnCount < maxSpawn; spawnCount++) 
        {
            Vector3 spawnerPos = new Vector3(Random.Range(-2, 2), 0.3f, transform.position.z);
            Instantiate(prefabObst, spawnerPos, prefabObst.transform.rotation);
            spawnCount++;
        }
        */
        if (spawnCount < maxSpawn)
        {
            Vector3 spawnerPos = new Vector3(Random.Range(-2, 2), 0.3f, transform.position.z);
            Instantiate(prefabObst, spawnerPos, prefabObst.transform.rotation);
            spawnCount++;
        }
        else if (maxSpawn >= spawnCount) 
        {
            FindObjectOfType<GameManager>().levelClear();
            maxSpawn *= 2;
        }
    }
}
