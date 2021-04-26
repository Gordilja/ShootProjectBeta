using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    private Vector3 enemy;
    public bool moveCam;

    private void Update()
    {
        
        moveCam = FindObjectOfType<GameManager>().move;
        if (moveCam == true) 
        {
            GameObject target = FindClosestEnemy();
            enemy = target.transform.position;
            player.transform.LookAt(enemy);
            if (enemy == null) 
            {
                enemy = player.transform.position;
            }
            //target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(enemy.x, enemy.y, transform.position.z));
            //rotation = Quaternion.Euler(target.y, -target.x, 0);
            //player.transform.rotation = rotation;
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
