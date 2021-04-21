using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombie : MonoBehaviour
{
    float speed = 3;
    Animator manimation;
    public bool move;
    int isHitHash;

    // Start is called before the first frame update
    void Start()
    {
        move = true;
        FindObjectOfType<AudioManager>().idlePlay();
        manimation = GetComponent<Animator>();
        isHitHash = Animator.StringToHash("isHit");
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true) 
        {
            
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            if (transform.position.z < -19)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") 
        {
            move = false;
            manimation.SetBool(isHitHash, true);
            FindObjectOfType<AudioManager>().deathPlay();
            GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
            StartCoroutine(die());
        }
    }

    public void death() 
    {
        move = false;
        manimation.SetBool(isHitHash, true);  
        StartCoroutine(die());
    }

    IEnumerator die() 
    {
        FindObjectOfType<SaveData>().scoreUp();
        yield return new WaitForSeconds(2);
        manimation.SetBool(isHitHash, false);
        Destroy(gameObject);
    }
}
