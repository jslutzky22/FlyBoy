using TMPro;
using UnityEngine;

public class DistanceLabel : MonoBehaviour
{
    private Transform playerTransform;
    private Transform camTransform;
    private TMP_Text distanceLabel;
    private void Start()
    {
        distanceLabel = GetComponentInChildren<TMP_Text>();
        playerTransform = FindAnyObjectByType<FlyingController>().transform;
        camTransform = Camera.main.transform;
    }

    void Update()
    {
        transform.forward = camTransform.forward;
        distanceLabel.text = Mathf.Round(Vector3.Distance(transform.position, playerTransform.position)) + " ft";
    }
}
