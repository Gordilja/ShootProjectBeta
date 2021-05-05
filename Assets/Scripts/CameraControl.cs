using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public bool moveCam;
    public GameObject player;
    private GameObject target;
    private Vector3 enemy; 
  
    private void Update()
    {
        
        moveCam = FindObjectOfType<GameManager>().move;
        if (moveCam == true) 
        {

            target = FindClosestEnemy();
            if (target == null) 
            {
                return;
            }
            enemy = target.transform.position;
            player.transform.LookAt(enemy);

            /*
            Vector3 rotation = Quaternion.LookRotation(enemy).eulerAngles;
            rotation.x = player.transform.rotation.x;
            rotation.y = enemy.y + 0.3f;
            rotation.z = player.transform.rotation.z;

            transform.rotation = Quaternion.Euler(rotation);
            */

            //player.transform.Rotate(target.transform.position.x, 0, 0, Space.World);

            /*
            Vector3 MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            target = transform.GetComponent<Camera>().ScreenToWorldPoint(MousePos);
            Quaternion rotation = Quaternion.Euler(target.y, -target.x, 0);
            */
        }   
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] findenemy = GameObject.FindGameObjectsWithTag("Zombie");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject zombie in findenemy)
        {
            Vector3 diff = zombie.transform.position - position;
            //Quaternion diffRot = Quaternion.Euler(position.y, -position.x, 0);
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = zombie;
                distance = curDistance;
            }
        }
        return closest;
    }
}
