using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PizzaDeliveryHandler : MonoBehaviour
{
    public static PizzaDeliveryHandler instance;
    private DeliveryPointCollision[] deliveryPoints;
    public int ActivePoints;
    [SerializeField] private Slider rentBar;

    [SerializeField] private float minDeliveryDelay;
    [SerializeField] private float maxDeliveryDelay;

    [SerializeField] private int maxVisiblePoints;

    public float Money;
    public float Rent;

    void Start()
    {
        instance = this;

        if (rentBar)
        {
            rentBar.maxValue = Rent;
        }
        else
        {
            Debug.LogWarning("Rent bar not set in inspector");
        }

        deliveryPoints = GetComponentsInChildren<DeliveryPointCollision>(true);

        for (int i = 0; i < maxVisiblePoints - 1; i++)
        {
            SpawnDeliveryPoint();
        }

        NewDeliveryPointWithDelay();
    }

    private void NewDeliveryPointWithDelay()
    {
        //  immediately spawn point if all are disabled
        if (ActivePoints == 0)
        {
            // Debug.Log("No more points");
            SpawnDeliveryPoint();
        }
        else
        {
            StartCoroutine(SpawnDelay());
        }
    }

    //  for immediately spawning a delivery point
    private void SpawnDeliveryPoint()
    {
        int index = Random.Range(0, deliveryPoints.Length);
        deliveryPoints[index].gameObject.SetActive(true);
    }

    private IEnumerator SpawnDelay()
    {
        float delay = Random.Range(minDeliveryDelay, maxDeliveryDelay);

        yield return new WaitForSeconds(delay);

        SpawnDeliveryPoint();
    }

    public void IncreaseMoney(float tipMoney)
    {
        Money += tipMoney;

        if (rentBar)
        {
            rentBar.value = Money;
        }

        NewDeliveryPointWithDelay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
