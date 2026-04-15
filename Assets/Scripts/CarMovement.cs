using System.Collections;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody rb;
    public int jumpPower;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(CarJump());
    }

    public IEnumerator CarJump()
    {
        yield return new WaitForSeconds(Random.Range(0, 90));
        Vector3 jumpForce = new Vector3(0, jumpPower * Random.Range(1f, 2f), 0);
        rb.AddForce(jumpForce);
        StartCoroutine(CarJump());
    }

}
