using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    [Serializable]
    protected struct TimeFormat
    {
        public int minutes;
        [Range(0, 59)] public float seconds;
    }

    [SerializeField] private TimeFormat timeLimit;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private int winIndex;
    [SerializeField] private int loseIndex;
    [SerializeField] private bool tutorialLevel;

    private void Start()
    {
        instance = this;
        timerText = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        if (!tutorialLevel)
        {
            timerCountdown();
        }
    }

    private void timerCountdown()
    {
        if (timeLimit.minutes <= 0 && timeLimit.seconds <= 0)
        {
            timerText.text = "0:00";
            SceneManager.LoadScene("Lose");
            return;
        }

        timeLimit.seconds -= Time.deltaTime;

        if (timeLimit.seconds < 0 && timeLimit.minutes > 0)
        {
            timeLimit.minutes--;
            timeLimit.seconds = 59;
        }

        int roundedSeconds = (int)Mathf.Round(timeLimit.seconds);

        timerText.text = timeLimit.minutes + ":" + (roundedSeconds < 10 ? "0" : "") + roundedSeconds;
    }

    public void winCheck()
    {
        if(PizzaDeliveryHandler.instance.Money >= PizzaDeliveryHandler.instance.Rent && !tutorialLevel)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
