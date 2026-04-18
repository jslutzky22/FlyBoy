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
    private MeshRenderer arrowMeshRenderer;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private Material redMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        arrow = transform.GetChild(0);
        arrowMeshRenderer = arrow.GetComponentInChildren<MeshRenderer>();
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
        if (selectedObj.GetComponent<DeliveryPointCollision>())
        {
            arrowMeshRenderer.material = greenMaterial;
        }
        else
        {
            arrowMeshRenderer.material = redMaterial;
        }

            arrow.gameObject.SetActive(true);
    }

    public void HideArrow()
    {
        selectedObj = null;
        arrow.gameObject.SetActive(false);
        ArrowPoint.instance.distanceText.text = "No objective selected";
    }
}
