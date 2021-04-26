using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public Rigidbody bulletPref;
    public Transform tip;
    public ParticleSystem flash;
    public int bulletCount = 0;
    public bool moveGun;


    // Update is called once per frame
    void Update()
    {
        moveGun = FindObjectOfType<GameManager>().move;

        if (bulletCount < 30)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
        else if (bulletCount == 30) 
        {
            StartCoroutine(reload());
        } 
    }

    IEnumerator reload() 
    {
        FindObjectOfType<AudioManager>().reloadPlay();
        yield return new WaitForSeconds(1.5f);
        bulletCount = 0;
    }

    void Shoot()
    {
        if (moveGun == true) 
        {
            bulletCount++;
            flash.Play();
            FindObjectOfType<GameManager>().play();
            Instantiate(bulletPref, tip.position, tip.transform.rotation);
            FindObjectOfType<AudioManager>().bangPlay();
        }
    }
}
