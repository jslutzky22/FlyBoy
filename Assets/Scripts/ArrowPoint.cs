using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowPoint : MonoBehaviour
{

    [SerializeField] private Transform selectedObj;
    private Transform playerTransform;
    [SerializeField] private TMP_Text distanceText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = FindFirstObjectByType<FlyingController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedObj)
        {
            transform.forward = selectedObj.position - playerTransform.position;
            distanceText.text = Mathf.Round(Vector3.Distance(selectedObj.position, playerTransform.position)).ToString();
        }
    }
}
