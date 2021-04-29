using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject bulletPref;
    public GameObject tip;
    public ParticleSystem flash;

    //User req
    public int bulletCount = 0;
    public bool moveGun;

    //Raycast try
    public Camera fpsCam;
    public float range = 100f;
    float damage = 10f;
    public RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        moveGun = FindObjectOfType<GameManager>().move;

        if (bulletCount < 30)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && moveGun)
            {
                //ShootRay();
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
            if (FindObjectOfType<SpawnManager>().spawnCount == FindObjectOfType<SpawnManager>().spawnCount++) 
            {
               Instantiate(bulletPref, tip.transform.position, tip.transform.rotation);
            }
            
            FindObjectOfType<AudioManager>().bangPlay();
        }
    }

    void ShootRay() 
    {
        Ray firedRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward);

        if (Physics.Raycast(firedRay, out hit, range, LayerMask.GetMask("Rifle")))
        {
            Debug.Log(transform.name);
            Debug.DrawRay(firedRay.origin, firedRay.direction * 10, Color.yellow);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null) 
            {
                target.TakeDamage(damage);
            }
        }

        bulletCount++;
        flash.Play();
        FindObjectOfType<GameManager>().play();
        FindObjectOfType<AudioManager>().bangPlay();
    }
}
