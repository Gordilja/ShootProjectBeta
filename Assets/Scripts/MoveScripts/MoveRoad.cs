using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    float speed = 20;
    public bool moveRoad;

    // Update is called once per frame
    void Update()
    {
        moveRoad = FindObjectOfType<GameManager>().move;
        if (moveRoad == true)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
