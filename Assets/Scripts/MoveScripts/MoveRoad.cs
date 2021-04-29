using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    float speed = 30;

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameManager>().move)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
