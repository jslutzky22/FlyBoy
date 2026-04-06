using Unity.VisualScripting;
using UnityEngine;

public class FlyingController : MonoBehaviour
{
    public float moveSpeed;
    public float maxFloatHeight;
    public float minFloatHeight;

    public Camera playerCamera;
    public float currentHeight;
    private bool moving = false;

    private float xRotation;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHeight = transform.position.y;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xRotation = playerCamera.transform.eulerAngles.x; 

        if (moving)
        {
            MoveCharacter();
        }
        else
        {
            DisableMovement();
        }

        rb.linearVelocity = rb.linearVelocity * .95f;
        currentHeight = Mathf.Clamp(transform.position.y, currentHeight, maxFloatHeight);
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
    }

    private void MoveCharacter()
    {
        Vector3 cameraForward = new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z);
        transform.rotation = Quaternion.LookRotation(cameraForward);
        transform.Rotate(new Vector3(xRotation, 0, 0), Space.Self);

        Vector3 forward = playerCamera.transform.forward;
        Vector3 flyDirection = forward.normalized;

        currentHeight += flyDirection.y * moveSpeed * Time.deltaTime;
        currentHeight = Mathf.Clamp(currentHeight, minFloatHeight, maxFloatHeight);

        rb.AddForce(flyDirection * moveSpeed * Time.deltaTime * 500); 
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
    }

    private void DisableMovement()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    public void OnMoving()
    {
        moving = true;
    }

    public void OnMovingStopped()
    {
        moving = false;
    }
}
