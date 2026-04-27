using UnityEngine;

public class FloatingRings : MonoBehaviour
{
    [SerializeField] private GameObject hoop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FlyBoy")
        {           
            FindFirstObjectByType<MasterSwatter>().floatingRing = true;
            FindFirstObjectByType<Timer>().floatingRings = true;
            hoop.SetActive(false);
        }
    }
}
