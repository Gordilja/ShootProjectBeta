using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    //public GameObject bulletPref;
    public GameObject raycaster;
    public ParticleSystem flash;

    //User req
    public int bulletCount;
    public bool moveGun;

    //Raycast try
    public Camera fpsCam;
    public float range;
    float damage = 10f;

    private void Start()
    {
        range = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameManager>().activePanel)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                FindObjectOfType<GameManager>().play();
            }
        }
        else if (!FindObjectOfType<GameManager>().activePanel) 
        {
            moveGun = FindObjectOfType<GameManager>().move;

            if (bulletCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && moveGun)
                {
                    ShootRay();
                    //Shoot();
                }
            }
            else if (bulletCount == 0)
            {
                StartCoroutine(reload());
            }
        } 
    }

    IEnumerator reload() 
    {
        FindObjectOfType<AudioManager>().reloadPlay();
        yield return new WaitForSeconds(1.5f - .25f);
        yield return new WaitForSeconds(.25f);
        bulletCount = 30;
    }

    /*
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
    */

    void ShootRay() 
    {
        Vector3 fwd = raycaster.transform.TransformDirection(Vector3.forward) * range;
        Ray firedRay = new Ray(raycaster.transform.position, fwd);
        RaycastHit hit;

        if (Physics.Raycast(firedRay, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(raycaster.transform.position, fwd, Color.red);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null) 
            {
                target.TakeDamage(damage);
            }
        }

        bulletCount--;
        flash.Play();     
        FindObjectOfType<AudioManager>().bangPlay();
    }
}
