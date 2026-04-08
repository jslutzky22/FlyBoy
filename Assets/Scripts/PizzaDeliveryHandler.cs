using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PizzaDeliveryHandler : MonoBehaviour
{
    public static PizzaDeliveryHandler instance;
    private DeliveryPointCollision[] deliveryPoints;
    public int ActivePoints;
    [SerializeField] private Slider rentBar;
    [SerializeField] private TMP_Text rentText;

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

        if (rentText)
        {
            rentText.text = "$0.00/$" + Rent;
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

    public void NewDeliveryPointWithDelay()
    {
        //  spawn immediately when no active points
        if (ActivePoints == 0)
        {
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
        if (!deliveryPoints[index].gameObject.activeSelf)
        {
            deliveryPoints[index].gameObject.SetActive(true);
        }
        else
        {
            //  repeat function if chosen point already active
            SpawnDeliveryPoint();
        }
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
            string moneyString = (Mathf.Round(Money*100)).ToString();
            moneyString = moneyString.Substring(0, moneyString.Length - 2) + "." + moneyString.Substring(moneyString.Length - 2);

            rentBar.value = Money;
            rentText.text = "$" + moneyString + "/$" + Rent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
