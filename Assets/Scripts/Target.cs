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
        FindObjectOfType<FlashEffectSample>().Flash();

        if (health == 0f)
        {
            Die();
        }
    }

    public void Die() 
    {
        StartCoroutine(enumDie());
    }

    IEnumerator enumDie()
    {
        //FindObjectOfType<MoveZombie>().hit = true;
        gameObject.tag = "Untagged";  
        manimation.SetBool(isHitHash, true);
        FindObjectOfType<SaveData>().scoreUp();
        FindObjectOfType<AudioManager>().deathPlay();
        GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
        yield return new WaitForSeconds(1f);
        manimation.SetBool(isHitHash, false);
        Destroy(gameObject);
    }
}
