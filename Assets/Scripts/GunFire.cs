using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public Rigidbody bulletPref;
    //public Vector3 spawnPos;
    public Transform tip;
    public ParticleSystem flash;

    // Update is called once per frame
    void Update()
    {
        //spawnPos = new Vector3(tip.transform.localPosition.x * tip.transform.localRotation.x, tip.transform.position.y, tip.transform.position.z);
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            flash.Play();
            FindObjectOfType<GameManager>().play();
            Instantiate(bulletPref, tip.position, tip.transform.rotation);
            FindObjectOfType<AudioManager>().bangPlay();
            //Shoot();
        }
    }
    /*
    void Shoot() 
    {
        RaycastHit hit;

        if (Physics.Raycast(shoot_cam.transform.position, shoot_cam.transform.forward, out hit)) 
        {
            Debug.Log(hit.transform);
            FindObjectOfType<MoveZombie>().death();
        }
    }
    */
}
