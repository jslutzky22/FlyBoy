using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowPoint : MonoBehaviour
{
    public static ArrowPoint instance;
    public Transform selectedObj;
    private Transform playerTransform;
    public TMP_Text distanceText;
    private Transform arrow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        arrow = transform.GetChild(0);
        playerTransform = FindFirstObjectByType<FlyingController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedObj)
        {
            arrow.forward = selectedObj.position - playerTransform.position;
            distanceText.text = Mathf.Round(Vector3.Distance(selectedObj.position, playerTransform.position)) + " ft";
        }
    }

    public void DisplayArrow()
    {
        arrow.gameObject.SetActive(true);
    }

    public void HideArrow()
    {
        arrow.gameObject.SetActive(false);
    }
}
