using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    private float speed = 2000;
    private Rigidbody rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(Vector3.forward * speed);
        if (transform.position.z > 50)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie") 
        {
            Destroy(gameObject);
        }
    }
}
