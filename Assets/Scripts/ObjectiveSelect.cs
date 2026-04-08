using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectiveSelect : MonoBehaviour
{
    private InputAction flyVision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flyVision = InputSystem.actions.FindAction("FlyVision");
        flyVision.performed += FlyVision;
    }

    private void FlyVision(InputAction.CallbackContext obj)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
