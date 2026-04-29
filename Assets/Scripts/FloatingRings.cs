using UnityEngine;

public class FloatingRings : MonoBehaviour
{
    [SerializeField] private GameObject hoop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FlyBoy")
        {           
            FindFirstObjectByType<MasterSwatter>().floatingRing = true;
            int i = FindFirstObjectByType<HoopManager>().deliveryPoints.Length;
            while (i > 0)
            {
                FindFirstObjectByType<HoopManager>().deliveryPoints[i - 1].GetComponent<DeliveryPointCollision>().floatingRings = true;
                i--;
            }
            hoop.SetActive(false);
        }
    }
}
