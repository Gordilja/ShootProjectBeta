using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    float speed = 20;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
