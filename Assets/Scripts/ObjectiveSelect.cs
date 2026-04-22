using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ObjectiveSelect : MonoBehaviour
{
    public static ObjectiveSelect instance;

    private InputAction flyVision;
    public static bool flyVisionEnabled;
    [SerializeField][Range(0, 1)] private float slowDownScale;
    private FlyingController player;
    [SerializeField] private LayerMask hitScanMask;
    [SerializeField] private Camera UICam;
    [SerializeField] private GameObject visionFilter;
    [SerializeField] private Image reticle;

    [Serializable]
    private struct ReticleColor
    {
        public Color normal;
        public Color selected;
    }

    [SerializeField] private ReticleColor reticleColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        player = FindFirstObjectByType<FlyingController>();
        flyVision = InputSystem.actions.FindAction("FlyVision");

        flyVision.performed += FlyVision;
        flyVision.canceled += FlyVisionInputCanceled;
    }

    private void FlyVision(InputAction.CallbackContext obj)
    {
        if (PauseScript.gamePaused)
        {
            return;
        }

        flyVisionEnabled = true;
        //Debug.Log("vision");
        Time.timeScale = slowDownScale;
        if (visionFilter)
        {
            visionFilter.SetActive(true);
        }
        else
        {
            Debug.Log("Vision filter not set");
        }
    }

    private void FlyVisionInputCanceled(InputAction.CallbackContext obj)
    {
        if (PauseScript.gamePaused)
        {
            return;
        }

        FlyVisionCanceled();
    }

    public void FlyVisionCanceled()
    {
        reticle.color = reticleColor.normal;
        flyVisionEnabled = false;
        //Debug.Log("no vision");
        Time.timeScale = 1;
        if (visionFilter)
        {
            visionFilter.SetActive(false);
        }

        if (Physics.Raycast(UICam.transform.position, UICam.transform.forward, out RaycastHit hit, 99999, hitScanMask))
        {
            Transform point = hit.transform;
            if (point)
            {
                ArrowPoint.instance.selectedObj = point;
                ArrowPoint.instance.DisplayArrow();
            }
        }
    }

    private void OnDestroy()
    {
        flyVision.performed -= FlyVision;
        flyVision.canceled -= FlyVisionInputCanceled;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flyVision.IsPressed())
        {
            return;
        }

        if (Physics.Raycast(UICam.transform.position, UICam.transform.forward, out RaycastHit hit, 99999, hitScanMask))
        {
            reticle.color = reticleColor.selected;
        }
        else
        {
            reticle.color = reticleColor.normal;
        }
    }
}
