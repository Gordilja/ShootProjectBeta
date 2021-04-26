using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabObst;
    int spawnCount;
    public int maxSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        maxSpawn = 10;
        InvokeRepeating("SpawnObstacle", 2, 1.4f);
    }
  
    void SpawnObstacle() 
    {
        if (spawnCount < maxSpawn)
        {
            Vector3 spawnerPos = new Vector3(Random.Range(-2, 2), 0.3f, transform.position.z);
            Instantiate(prefabObst, spawnerPos, prefabObst.transform.rotation);
            spawnCount++;
        } 
    }
}
