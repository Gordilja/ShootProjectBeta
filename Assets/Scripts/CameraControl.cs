using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public bool moveCam;
    public GameObject player;
    private GameObject target;
    private Vector3 enemy;
    public int counter;
  
    private void Update()
    {
        counter = FindObjectOfType<SaveData>().counterTag;
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
        }   
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] findenemy = GameObject.FindGameObjectsWithTag("Zombie " + counter);
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
