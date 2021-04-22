using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 target;
    public GameObject player;
    public Quaternion rotation;

    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        rotation = Quaternion.Euler(target.y, -target.x, 0);
        player.transform.rotation = rotation;
    }
}
