using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 20f;
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            FindObjectOfType<MoveZombie>().die();
        }
    }
}
