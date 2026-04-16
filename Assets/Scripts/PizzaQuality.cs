using System.Collections;
using TMPro;
using UnityEngine;

public class PizzaQuality : MonoBehaviour
{
    public static PizzaQuality instance;
    public float collisionPenalty;
    [SerializeField][Range(0, 1)] private float pointScaleFactor;
    //public int collisionNumber;
    private Rigidbody rb;
    [SerializeField] private float iFrameDuration;
    [SerializeField] private float minimumVelocity;
    [SerializeField] private float labelDuration;
    private bool invulnerable;
    [SerializeField] private GameObject penaltyLabel;
    private TMP_Text pentaltyText;

    [SerializeField] private GameObject moneyGainLabel;
    private TMP_Text moneyGainText;

    private void Start()
    {
        instance = this;
        pentaltyText = penaltyLabel.GetComponent<TMP_Text>();
        moneyGainText = moneyGainLabel.GetComponent<TMP_Text>();
        rb = GetComponent<Rigidbody>();
    }

    public void DisplayMoney(float moneyGain)
    {
        StartCoroutine(DisplayMoneyCoroutine(moneyGain));
    }

    private IEnumerator DisplayMoneyCoroutine(float moneyGain)
    {
        string labelText = (Mathf.Round(moneyGain * 100)).ToString();
        labelText = labelText.Substring(0, labelText.Length - 2) + "." + labelText.Substring(labelText.Length - 2);
        moneyGainText.text = "+ $" + labelText;
        moneyGainLabel.SetActive(true);
        yield return new WaitForSeconds(labelDuration);
        moneyGainLabel.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!invulnerable && rb.linearVelocity.magnitude >= minimumVelocity)
        {
            StartCoroutine(IFrames());
            float penaltyCalculation = rb.linearVelocity.magnitude * pointScaleFactor;
            StartCoroutine(DisplayPenalty(penaltyCalculation));
            collisionPenalty += penaltyCalculation;
        }
    }

    private IEnumerator DisplayPenalty(float collisionPenalty)
    {
        string labelText = (Mathf.Round(collisionPenalty * 100)).ToString();
        labelText = labelText.Substring(0, labelText.Length - 2) + "." + labelText.Substring(labelText.Length - 2);
        pentaltyText.text = "- $" + labelText;
        penaltyLabel.SetActive(true);
        yield return new WaitForSeconds(labelDuration);
        penaltyLabel.SetActive(false);
    }

    private IEnumerator IFrames()
    {
        invulnerable = true;
        yield return new WaitForSeconds(iFrameDuration);
        invulnerable = false;
    }
}
