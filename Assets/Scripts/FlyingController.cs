using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingController : MonoBehaviour
{
    public float moveSpeed;
    public float hyperSpeedMultiplier;
    private bool hyperSpeeding;
    public float maxFloatHeight;
    public float minFloatHeight;
    public float maxSpeed;

    public Camera playerCamera;
    public float currentHeight;
    private bool moving = false;

    private float xRotation;
    private float zRotation;

    private float velocity;

    public Animator animator;

    private Rigidbody rb;

    private AudioSource audioSource;
    public AudioClip bonk;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHeight = transform.position.y;

        Cursor.lockState = CursorLockMode.Locked;

        audioSource = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xRotation = playerCamera.transform.eulerAngles.x;
        zRotation = playerCamera.transform.eulerAngles.z;

        if (moving)
        {
            MoveCharacter();
        }
        else
        {
            DisableMovement();
        }

        rb.linearVelocity = rb.linearVelocity * .95f;
        if (transform.position.y < minFloatHeight)
        {
            transform.position = new Vector3(transform.position.x, minFloatHeight, transform.position.z);
        }
        if (transform.position.y > maxFloatHeight)
        {
            transform.position = new Vector3(transform.position.x, maxFloatHeight, transform.position.z);
        }
        velocity = rb.linearVelocity.magnitude;

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.maxLinearVelocity = maxSpeed;
        }
    }

    private void MoveCharacter()
    {
        animator.SetBool("FlyingAnimation", true);
        Vector3 cameraForward = new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z);
        transform.rotation = Quaternion.LookRotation(cameraForward);
        transform.Rotate(new Vector3(xRotation, 0, zRotation), Space.Self);

        Vector3 forward = playerCamera.transform.forward;
        Vector3 flyDirection = forward.normalized;

        if (hyperSpeeding)
        {
            rb.AddForce(flyDirection * moveSpeed * Time.deltaTime * 500 * hyperSpeedMultiplier);
        }
        else
        {
            rb.AddForce(flyDirection * moveSpeed * Time.deltaTime * 500);
        }
    }

    private void DisableMovement()
    {
        animator.SetBool("FlyingAnimation", false);
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

    public void OnHyperSpeed()
    {
        hyperSpeeding = true;
        StartCoroutine(ZoomOut());
    }

    public void OnHyperSpeedStop()
    {
        hyperSpeeding = false;
        StartCoroutine(ZoomIn());
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.pitch = Random.Range(.80f, 1.20f);
        audioSource.PlayOneShot(bonk, Random.Range(0.50f, 1));
    }

    public IEnumerator ZoomOut()
    {
        playerCamera.fieldOfView = 40;
        for (int i = 0; i < 100; i++)
        {
            playerCamera.fieldOfView += .01f;
            yield return new WaitForSeconds(0.1f);
        }
        //playerCamera.fieldOfView = 50;
    }

    public IEnumerator ZoomIn()
    {
        for (int i = 0; i < 100; i++)
        {
            playerCamera.fieldOfView -= .01f;
            yield return new WaitForSeconds(0.1f);
        }
        playerCamera.fieldOfView = 40;
    }
    
    public void OnClick()
    {
        FindAnyObjectByType<SkillCheck>().OnClick();
    }
}
