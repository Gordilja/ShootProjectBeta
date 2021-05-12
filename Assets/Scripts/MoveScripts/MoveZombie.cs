using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombie : MonoBehaviour
{
    float speed = 5;
    public bool moveZombie;
    public bool hit;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().idlePlay();
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveZombie = FindObjectOfType<GameManager>().move;
        if (moveZombie == true && hit == false) 
        {    
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            if (transform.position.z <= -15 && transform.position.z >= -19) 
            {
                FindObjectOfType<GameManager>().slowMotion();
            }
            else if (transform.position.z <= -19)
            {
                Destroy(gameObject);
                FindObjectOfType<GameManager>().gameEnd();
            }
        }
    }

 
}
