using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabObst;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2, 1.4f);
    }

    void SpawnObstacle() 
    {
        Vector3 spawnerPos = new Vector3(Random.Range(-2, 2), 0.3f, 10);
        Instantiate(prefabObst, spawnerPos, prefabObst.transform.rotation);
    }
}
