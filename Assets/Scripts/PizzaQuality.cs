using UnityEngine;

public class PizzaQuality : MonoBehaviour
{
    public static PizzaQuality instance;
    public float collisionPenalty;
    public int collisionNumber;

    private void Start()
    {
        instance = this;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PizzaDamager"))
        {
            collisionNumber++;
        }
    }
}
