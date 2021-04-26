using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 target;
    public GameObject player;
    public Quaternion rotation;
    public bool moveCam;

    void Update()
    {
        moveCam = FindObjectOfType<GameManager>().move;
        if (moveCam == true) 
        {
            //GameObject[] gos = GameObject.FindGameObjectsWithTag("Zombie");
            target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            rotation = Quaternion.Euler(target.y, -target.x, 0);
            player.transform.rotation = rotation;
        }   
    }

    /*
    public GameObject FindClosestEnemy(float min, float max)
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Zombie");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        // calculate squared distances
        min = min * min;
        max = max * max;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance >= min && curDistance <= max)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    */
}
