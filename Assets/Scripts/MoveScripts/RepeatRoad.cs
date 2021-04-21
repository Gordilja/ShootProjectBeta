using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth; //= 26;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(0, 0, 0);
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 24.8) 
        {
            transform.position = startPos;
        }
    }
}
