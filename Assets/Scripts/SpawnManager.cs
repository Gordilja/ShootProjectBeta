using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabObst;
    public int spawnCount;
    public int spawnNum;
    public int maxSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnCount = FindObjectOfType<SaveData>().score;
        InvokeRepeating("SpawnObstacle", 2, 1.4f);
        maxSpawn = 10;
        spawnNum = 0;
    }
    private void Update()
    {
        spawnCount = FindObjectOfType<SaveData>().score;
    }

    void SpawnObstacle() 
    {
        if ((FindObjectOfType<GameManager>().move) && (spawnNum != maxSpawn) && (spawnCount < maxSpawn))
        {
            Vector3 spawnerPos = new Vector3(Random.Range(-2, 2), 0.3f, transform.position.z);
            Instantiate(prefabObst, spawnerPos, prefabObst.transform.rotation);
            spawnNum++;
        }
        else if ((maxSpawn == spawnCount) && (spawnNum == maxSpawn)) 
        {
            FindObjectOfType<GameManager>().levelClear();
        }
    }
}
