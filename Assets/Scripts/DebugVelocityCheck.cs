using TMPro;
using UnityEngine;

public class DebugVelocityCheck : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private TMP_Text speedDisplay;
    void Start()
    {
        playerRigidbody = FindFirstObjectByType<FlyingController>().GetComponent<Rigidbody>();
        speedDisplay = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speedDisplay.text = "velocity: " + playerRigidbody.linearVelocity.magnitude;
    }
}
