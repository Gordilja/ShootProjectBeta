using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 20f;
    int isHitHash;
    Animator manimation;

    private void Start()
    {
        manimation = GetComponent<Animator>();
        isHitHash = Animator.StringToHash("isHit");
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health > 0) 
        {
            FindObjectOfType<FlashEffectSample>().Flash();
        }        

        if (health == 0f)
        {
            FindObjectOfType<FlashEffectSample>().Flash();
            Die();    
        }
    }

    public void Die() 
    {
        StartCoroutine(DieEnum());
    }

    IEnumerator DieEnum()
    {
        FindObjectOfType<MoveZombie>().hit = true;
        gameObject.tag = "Untagged";
        manimation.SetBool(isHitHash, true);
        FindObjectOfType<AudioManager>().deathPlay();
        GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
        yield return new WaitForSeconds(1f);  
        manimation.SetBool(isHitHash, false);
        FindObjectOfType<SaveData>().scoreUp();
        Destroy(gameObject);
    }
}
