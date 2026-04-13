using System.Collections;
using UnityEngine;

public class PizzaQuality : MonoBehaviour
{
    public static PizzaQuality instance;
    public float collisionPenalty;
    [SerializeField][Range(0, 1)] private float pointScaleFactor;
    //public int collisionNumber;
    private Rigidbody rb;
    [SerializeField] private float iFrameDuration;
    private bool invulnerable;

    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!invulnerable)
        {
            StartCoroutine(IFrames());
            collisionPenalty += rb.angularVelocity.magnitude * pointScaleFactor;
        }
    }

    private IEnumerator IFrames()
    {
        invulnerable = true;
        yield return new WaitForSeconds(iFrameDuration);
        invulnerable = false;
    }
}
