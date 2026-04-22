using TMPro;
using UnityEngine;

public class DistanceLabel : MonoBehaviour
{
    private Transform playerTransform;
    private Transform camTransform;
    private TMP_Text distanceLabel;
    private float defaultScale;

    private void Start()
    {
        distanceLabel = GetComponentInChildren<TMP_Text>();
        playerTransform = FindAnyObjectByType<FlyingController>().transform;
        camTransform = Camera.main.transform;
        defaultScale = transform.localScale.x;
    }

    void Update()
    {
        if (!ObjectiveSelect.flyVisionEnabled)
        {
            transform.localScale = Vector3.one * defaultScale;
        }
        else
        {
            transform.localScale = Vector3.one * defaultScale * 5;
        }

            transform.forward = camTransform.forward;
        distanceLabel.text = Mathf.Round(Vector3.Distance(transform.position, playerTransform.position)) + " ft";
    }
}
