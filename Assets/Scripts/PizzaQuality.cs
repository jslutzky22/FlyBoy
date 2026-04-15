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
    [SerializeField] private float labelDuration;
    private bool invulnerable;
    [SerializeField] private GameObject penaltyLabel;
    private TMP_Text pentaltyText;

    private void Start()
    {
        instance = this;
        pentaltyText = penaltyLabel.GetComponent<TMP_Text>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!invulnerable)
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
