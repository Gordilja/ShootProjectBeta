using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    private Vector3 startPos;
    public float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(0, 0, 0);
        repeatWidth = 32.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > repeatWidth) 
        {
            transform.position = startPos;
        }
    }
}
