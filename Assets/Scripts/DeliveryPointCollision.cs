using System.Collections;
using UnityEngine;

public class DeliveryPointCollision : MonoBehaviour
{
    [SerializeField] private float basePrice;
    [SerializeField] private float timeLimit;
    [SerializeField] private float timer;

    private void OnEnable()
    {
        timer = timeLimit;
        PizzaDeliveryHandler.instance.ActivePoints++;
        StartCoroutine(CountDownTimer());
    }

    private void OnDisable()
    {
        PizzaDeliveryHandler.instance.ActivePoints--;
        StopAllCoroutines();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        gameObject.SetActive(false);

        //  not final calculation
        float tipCalculation = basePrice + timer;
        //  penalty can not go below base price
        tipCalculation = Mathf.Max(basePrice,
                                  (tipCalculation - PizzaQuality.instance.collisionNumber * PizzaQuality.instance.collisionPenalty));
        //  rounding to nearest hundredth
        tipCalculation = Mathf.Round(tipCalculation * 100)/100;

        Debug.Log("Gained $"+tipCalculation);
        PizzaDeliveryHandler.instance.IncreaseMoney(tipCalculation);

        PizzaQuality.instance.collisionNumber = 0;
    }

    private IEnumerator CountDownTimer()
    {
        while (timer > 0 && gameObject.activeSelf)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }

}
