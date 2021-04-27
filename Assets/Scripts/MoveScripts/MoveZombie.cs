using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombie : MonoBehaviour
{
    float speed = 2;
    Animator manimation;
    public bool moveZombie;
    bool hit;
    int isHitHash;

    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        FindObjectOfType<AudioManager>().idlePlay();
        manimation = GetComponent<Animator>();
        isHitHash = Animator.StringToHash("isHit");
    }

    // Update is called once per frame
    void Update()
    {
        moveZombie = FindObjectOfType<GameManager>().move;
        if (moveZombie == true && hit == false) 
        {    
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            if (transform.position.z < -19)
            {
                Destroy(gameObject);
                FindObjectOfType<GameManager>().gameEnd();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") 
        {
            hit = true;
            manimation.SetBool(isHitHash, true);
            FindObjectOfType<AudioManager>().deathPlay();
            GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
            StartCoroutine(die());
        }
    }
/*
    public void death() 
    {
        moveZombie = false;
        manimation.SetBool(isHitHash, true);  
        StartCoroutine(die());
    }
*/
    IEnumerator die() 
    {
        FindObjectOfType<SaveData>().scoreUp();
        yield return new WaitForSeconds(1);
        manimation.SetBool(isHitHash, false);
        Destroy(gameObject);
    }
}
