using UnityEngine;

public class Spin : MonoBehaviour
{
    public Vector3 spin;
    public int spinSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spin * spinSpeed * Time.deltaTime);
    }
}
