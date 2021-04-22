using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public Rigidbody bulletPref;
    //public Vector3 spawnPos;
    public Transform tip;
    public ParticleSystem flash;
    public int bulletCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (bulletCount < 30)
        {
            //spawnPos = new Vector3(tip.transform.localPosition.x * tip.transform.localRotation.x, tip.transform.position.y, tip.transform.position.z);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
        else if (bulletCount == 30) 
        {
            StartCoroutine(reload());
            //return;
        } 
    }

    IEnumerator reload() 
    {    
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<AudioManager>().reloadPlay();
        bulletCount = 0;
    }

    void Shoot() 
    {
        bulletCount++;
        flash.Play();
        FindObjectOfType<GameManager>().play();
        Instantiate(bulletPref, tip.position, tip.transform.rotation);
        FindObjectOfType<AudioManager>().bangPlay();
    }
}
