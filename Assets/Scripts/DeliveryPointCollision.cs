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
        //  not final calculation
        gameObject.SetActive(false);
        PizzaDeliveryHandler.instance.IncreaseMoney(basePrice + timer);
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
