using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryPointCollision : MonoBehaviour
{
    [SerializeField] private float basePrice;
    [SerializeField] private float timeLimit;
    [SerializeField] private float timer;
    [SerializeField] private GameObject moneyParticle;
    [SerializeField] private Slider timerVisual;
    [SerializeField] private AudioClip moneySound;

    private void Start()
    {
        timerVisual.maxValue = timeLimit;
    }

    private void OnEnable()
    {
        timer = timeLimit;
        timerVisual.value = timer;
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

        //other.GetComponent<FlyingController>().MoneyMoneyMoney();

        Instantiate(moneyParticle, other.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(moneySound, transform.position);
        if (PizzaDeliveryHandler.instance.ActivePoints == 1)
        {
            PizzaDeliveryHandler.instance.SpawnDeliveryPoint();
        }
        else
        {
            PizzaDeliveryHandler.instance.NewDeliveryPointWithDelay();
        }

        gameObject.SetActive(false);

        ArrowPoint.instance.HideArrow();

        //  not final calculation
        float tipCalculation = basePrice + timer;
        //  penalty can not go below base price
        tipCalculation = Mathf.Max(basePrice,
                                  (tipCalculation - PizzaQuality.instance.collisionPenalty));
        //  rounding to nearest hundredth
        tipCalculation = Mathf.Round(tipCalculation * 100)/100;

        PizzaQuality.instance.DisplayMoney(tipCalculation);

        Debug.Log("Gained $"+tipCalculation);
        PizzaDeliveryHandler.instance.IncreaseMoney(tipCalculation);

        PizzaQuality.instance.collisionPenalty = 0;
    }

    private IEnumerator CountDownTimer()
    {
        while (timer > 0 && gameObject.activeSelf)
        {
            timer -= Time.deltaTime;
            timerVisual.value = timer;
            yield return null;
        }
    }

}
