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
    private bool movingLeft = false;
    private bool movingRight = false;
    private bool movingUp = false;
    private bool movingDown = false;

    private float xRotation;
    private float zRotation;

    private float velocity;

    public Animator animator;

    private Rigidbody rb;

    private AudioSource audioSource;
    public AudioClip bonk;
    public AudioClip speedUp;
    public AudioClip speedDown;
    public AudioClip money;

    public GameObject hitParticle;
    public GameObject moneyParticle;
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

        if (moving || movingLeft || movingRight)
        {
            if (moving)
            {
                MoveCharacter();
            }
            if (movingLeft)
            {
                MoveCharacterLeft();
            }
            if (movingRight) 
            {
                MoveCharacterRight();
            }
        }
        else
        {
            DisableMovement();
        }

        if (movingUp)
        {
            rb.AddForce(new Vector3(0, 50, 0));
        }
        if (movingDown)
        {
            rb.AddForce(new Vector3(0, -50, 0));
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

    private void MoveCharacterLeft()
    {
        animator.SetBool("FlyingAnimation", true);
        Vector3 cameraForward = new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z);
        transform.rotation = Quaternion.LookRotation(cameraForward);
        transform.Rotate(new Vector3(xRotation, 0, zRotation), Space.Self);

        Vector3 forward = -playerCamera.transform.right;
        Vector3 flyDirection = forward.normalized;

        if (hyperSpeeding)
        {
            rb.AddForce(flyDirection * moveSpeed * Time.deltaTime * 200 * hyperSpeedMultiplier);
        }
        else
        {
            rb.AddForce(flyDirection * moveSpeed * Time.deltaTime * 200);
        }
    }

    private void MoveCharacterRight()
    {
        animator.SetBool("FlyingAnimation", true);
        Vector3 cameraForward = new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z);
        transform.rotation = Quaternion.LookRotation(cameraForward);
        transform.Rotate(new Vector3(xRotation, 0, zRotation), Space.Self);

        Vector3 forward = playerCamera.transform.right;
        Vector3 flyDirection = forward.normalized;

        if (hyperSpeeding)
        {
            rb.AddForce(flyDirection * moveSpeed * Time.deltaTime * 200 * hyperSpeedMultiplier);
        }
        else
        {
            rb.AddForce(flyDirection * moveSpeed * Time.deltaTime * 200);
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

    public void OnMoveLeft()
    {
        movingLeft = true;
    }

    public void OnMoveLeftStopped()
    {
        movingLeft = false;
    }

    public void OnMoveRight()
    {
        movingRight = true;
    }

    public void OnMoveRightStopped()
    {
        movingRight = false;
    }

    public void OnGoUp()
    {
        movingUp = true;
    }

    public void OnGoUpStop()
    {
        movingUp = false;
    }

    public void OnGoDown()
    {
        movingDown = true;
    }

    public void OnGoDownStop()
    {
        movingDown = false;
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
        Instantiate(hitParticle, transform.position, Quaternion.identity);
        audioSource.pitch = Random.Range(.80f, 1.20f);
        audioSource.PlayOneShot(bonk, Random.Range(0.50f, 1));
    }

    public IEnumerator ZoomOut()
    {
        audioSource.pitch = Random.Range(.80f, 1.20f);
        audioSource.PlayOneShot(speedUp, Random.Range(0.50f, 1));
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
        audioSource.pitch = Random.Range(.80f, 1.20f);
        audioSource.PlayOneShot(speedDown, Random.Range(0.50f, 1));
        for (int i = 0; i < 100; i++)
        {
            playerCamera.fieldOfView -= .01f;
            yield return new WaitForSeconds(0.1f);
        }
        playerCamera.fieldOfView = 40;
    }
    
    public void OnClick()
    {
        SkillCheck check = FindAnyObjectByType<SkillCheck>();

        if (check)
        {
            check.OnClick();
        }
    }

    public void MoneyMoneyMoney()
    {
        //Debug.Log("MoneySoundShouldHavePlayed");
        audioSource.pitch = Random.Range(.80f, 1.20f);
        audioSource.PlayOneShot(money, Random.Range(0.50f, 1));
        Instantiate(moneyParticle, transform.position, Quaternion.identity);
        //Debug.Log("MoneySoundShouldHavePlayed");
    }
}
