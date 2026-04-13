using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MasterSwatter : MonoBehaviour
{
    [Header("Main Variables")]
    [SerializeField] private float swatterEventSystemTimer;
    private int swatterIndex = 0;
    [SerializeField] GameObject approvalRating;
    [SerializeField] GameObject swatterAppears;
    [SerializeField] TMP_Text swatterText;
    [SerializeField] GameObject pauseUI;

    [Header("City Health")]
    private int cityHealth;
    private int cityHealAmount;

    [Header("Events")]
    private bool eventActive;
    [SerializeField] private GameObject[] eventZeroObjects;
    [SerializeField] private GameObject[] eventOneObjects;
    [SerializeField] private GameObject[] eventTwoObjects;
    [SerializeField] private GameObject[] eventThreeObjects;
    [SerializeField] private GameObject[] eventFourObjects;
    [SerializeField] private GameObject[] eventFiveObjects;
    [SerializeField] private GameObject[] eventSixObjects;
    [SerializeField] private GameObject[] eventSevenObjects;
    [SerializeField] private GameObject[] eventEightObjects;
    [SerializeField] private GameObject[] eventNineObjects;
    [SerializeField] private GameObject[] eventTenObjects;
    [SerializeField] private GameObject[] eventElevenObjects;
    [SerializeField] private int eventWaitTimer;
    public bool flyBoyMadeItToEvent0;
    public bool flyBoyMadeItToEvent1;
    public bool flyBoyMadeItToEvent2;
    public bool flyBoyMadeItToEvent3;
    public bool flyBoyMadeItToEvent4;
    public bool flyBoyMadeItToEvent5;
    public bool flyBoyMadeItToEvent6;
    public bool flyBoyMadeItToEvent7;
    public bool flyBoyMadeItToEvent8;
    public bool flyBoyMadeItToEvent9;
    public bool flyBoyMadeItToEvent10;
    public bool flyBoyMadeItToEvent11;
    [SerializeField] int eventLoss;

    void Start()
    {
        StartCoroutine(SwatterEventSystem());
        cityHealth = 100;
    }

    IEnumerator SwatterEventSystem()
    {
        float timer = swatterEventSystemTimer;
        while (timer > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        swatterIndex = Random.Range(0, 12);
        if (swatterIndex == 0)
        {
            eventActive = true;
            StartCoroutine(EventZero());
            StartCoroutine(SwatterText());
        }
        else if (swatterIndex == 1)
        {
            eventActive = true;
            StartCoroutine(EventOne());
            StartCoroutine(SwatterText());
        }
        else if (swatterIndex == 2)
        {
            eventActive = true;
            StartCoroutine(EventTwo());
            StartCoroutine(SwatterText());
        }
        else if (swatterIndex == 3)
        {
            eventActive = true;
            StartCoroutine(EventThree());
            StartCoroutine(SwatterText());
        }
        else if (swatterIndex == 4)
        {
            eventActive = true;
            StartCoroutine(EventFour());
            StartCoroutine(SwatterText());
        }
        else if (swatterIndex == 5)
        {
            eventActive = true;
            StartCoroutine(EventFive());
            StartCoroutine(SwatterText());
        }
        else if (swatterIndex == 6)
        {
            eventActive = true;
            StartCoroutine(EventSix());
            StartCoroutine(SwatterText());
        }
        else if (swatterIndex == 7)
        {
            eventActive = true;
            StartCoroutine(EventSeven());
            StartCoroutine(SwatterText());
        }
        else if (swatterIndex == 8)
        {
            eventActive = true;
            StartCoroutine(EventEight());
            StartCoroutine(SwatterText());
        }
        else if (swatterIndex == 9)
        {
            eventActive = true;
            StartCoroutine(EventNine());
            StartCoroutine(SwatterText());
        }
        else if (swatterIndex == 10)
        {
            eventActive = true;
            StartCoroutine(EventTen());
            StartCoroutine(SwatterText());
        }
        else if (swatterIndex == 11)
        {
            eventActive = true;
            StartCoroutine(EventEleven());
            StartCoroutine(SwatterText());
        }
        StartCoroutine(SwatterEventSystem());
    }

    IEnumerator SwatterText()
    {
        approvalRating.SetActive(false);
        swatterAppears.SetActive(true);
        if (swatterIndex == 0)
        {
            swatterText.text = "0";
        }
        else if (swatterIndex == 1)
        {
            swatterText.text = "1";
        }
        else if (swatterIndex == 2)
        {
            swatterText.text = "2";
        }
        else if (swatterIndex == 3)
        {
            swatterText.text = "3";
        }
        else if (swatterIndex == 4)
        {
            swatterText.text = "4";
        }
        else if (swatterIndex == 5)
        {
            swatterText.text = "5";
        }
        else if (swatterIndex == 6)
        {
            swatterText.text = "6";
        }
        else if (swatterIndex == 7)
        {
            swatterText.text = "7";
        }
        else if (swatterIndex == 8)
        {
            swatterText.text = "8";
        }
        else if (swatterIndex == 9)
        {
            swatterText.text = "9";
        }
        else if (swatterIndex == 10)
        {
            swatterText.text = "10";
        }
        else if (swatterIndex == 11)
        {
            swatterText.text = "11";
        }
        int timer2 = 5;
        while (timer2 > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            timer2--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        swatterAppears.SetActive(false);
        approvalRating.SetActive(true);
    }

    private void CityHeal()
    {
        cityHealth += cityHealAmount;
    }

    IEnumerator EventZero()
    {
        eventZeroObjects[0].SetActive(true);
        if (eventZeroObjects.Length == 2)
        { 
            eventZeroObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent0)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent0)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventZeroObjects[0].SetActive(false);
                if (eventZeroObjects.Length == 2)
                {
                    eventZeroObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent0 = false;
            }
            else 
            {
                cityHealth -= eventLoss;
                eventZeroObjects[0].SetActive(false);
                if (eventZeroObjects.Length == 2)
                {
                    eventZeroObjects[1].SetActive(true);
                }
                eventActive = false; 
                flyBoyMadeItToEvent0 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventZeroObjects[0].SetActive(false);
            if (eventZeroObjects.Length == 2)
            {
                eventZeroObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent0 = false;
        }
    }

    IEnumerator EventOne()
    {
        eventOneObjects[0].SetActive(true);
        if (eventOneObjects.Length == 2)
        {
            eventOneObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent1)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent1)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventOneObjects[0].SetActive(false);
                if (eventOneObjects.Length == 2)
                {
                    eventOneObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent1 = false;
            }
            else
            {
                cityHealth -= eventLoss;
                eventOneObjects[0].SetActive(false);
                if (eventOneObjects.Length == 2)
                {
                    eventOneObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent1 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventOneObjects[0].SetActive(false);
            if (eventOneObjects.Length == 2)
            {
                eventOneObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent1 = false;
        }
    }

    IEnumerator EventTwo()
    {
        eventTwoObjects[0].SetActive(true);
        if (eventTwoObjects.Length == 2)
        {
            eventTwoObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent2)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent2)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventTwoObjects[0].SetActive(false);
                if (eventTwoObjects.Length == 2)
                {
                    eventTwoObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent2 = false;
            }
            else
            {
                cityHealth -= eventLoss;
                eventTwoObjects[0].SetActive(false);
                if (eventTwoObjects.Length == 2)
                {
                    eventTwoObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent2 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventTwoObjects[0].SetActive(false);
            if (eventTwoObjects.Length == 2)
            {
                eventTwoObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent2 = false;
        }
    }

    IEnumerator EventThree()
    {
        eventThreeObjects[0].SetActive(true);
        if (eventThreeObjects.Length == 2)
        {
            eventThreeObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent3)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent3)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventThreeObjects[0].SetActive(false);
                if (eventThreeObjects.Length == 2)
                {
                    eventThreeObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent3 = false;
            }
            else
            {
                cityHealth -= eventLoss;
                eventThreeObjects[0].SetActive(false);
                if (eventThreeObjects.Length == 2)
                {
                    eventThreeObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent3 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventThreeObjects[0].SetActive(false);
            if (eventThreeObjects.Length == 2)
            {
                eventThreeObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent3 = false;
        }
    }

    IEnumerator EventFour()
    {
        eventFourObjects[0].SetActive(true);
        if (eventFourObjects.Length == 2)
        {
            eventFourObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent4)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent4)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventFourObjects[0].SetActive(false);
                if (eventFourObjects.Length == 2)
                {
                    eventFourObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent4 = false;
            }
            else
            {
                cityHealth -= eventLoss;
                eventFourObjects[0].SetActive(false);
                if (eventFourObjects.Length == 2)
                {
                    eventFourObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent4 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventFourObjects[0].SetActive(false);
            if (eventFourObjects.Length == 2)
            {
                eventFourObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent4 = false;
        }
    }

    IEnumerator EventFive()
    {
        eventFiveObjects[0].SetActive(true);
        if (eventFiveObjects.Length == 2)
        {
            eventFiveObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent5)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent5)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventFiveObjects[0].SetActive(false);
                if (eventFiveObjects.Length == 2)
                {
                    eventFiveObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent5 = false;
            }
            else
            {
                cityHealth -= eventLoss;
                eventFiveObjects[0].SetActive(false);
                if (eventFiveObjects.Length == 2)
                {
                    eventFiveObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent5 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventFiveObjects[0].SetActive(false);
            if (eventFiveObjects.Length == 2)
            {
                eventFiveObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent5 = false;
        }
    }

    IEnumerator EventSix()
    {
        eventSixObjects[0].SetActive(true);
        if (eventSixObjects.Length == 2)
        {
            eventSixObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent6)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent6)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventSixObjects[0].SetActive(false);
                if (eventSixObjects.Length == 2)
                {
                    eventSixObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent6 = false;
            }
            else
            {
                cityHealth -= eventLoss;
                eventSixObjects[0].SetActive(false);
                if (eventSixObjects.Length == 2)
                {
                    eventSixObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent6 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventSixObjects[0].SetActive(false);
            if (eventSixObjects.Length == 2)
            {
                eventSixObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent6 = false;
        }
    }

    IEnumerator EventSeven()
    {
        eventSevenObjects[0].SetActive(true);
        if (eventSevenObjects.Length == 2)
        {
            eventSevenObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent7)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent7)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventSevenObjects[0].SetActive(false);
                if (eventSevenObjects.Length == 2)
                {
                    eventSevenObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent7 = false;
            }
            else
            {
                cityHealth -= eventLoss;
                eventSevenObjects[0].SetActive(false);
                if (eventSevenObjects.Length == 2)
                {
                    eventSevenObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent7 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventSevenObjects[0].SetActive(false);
            if (eventSevenObjects.Length == 2)
            {
                eventSevenObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent7 = false;
        }
    }

    IEnumerator EventEight()
    {
        eventEightObjects[0].SetActive(true);
        if (eventEightObjects.Length == 2)
        {
            eventEightObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent8)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent8)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventEightObjects[0].SetActive(false);
                if (eventEightObjects.Length == 2)
                {
                    eventEightObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent8 = false;
            }
            else
            {
                cityHealth -= eventLoss;
                eventEightObjects[0].SetActive(false);
                if (eventEightObjects.Length == 2)
                {
                    eventEightObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent8 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventEightObjects[0].SetActive(false);
            if (eventEightObjects.Length == 2)
            {
                eventEightObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent8 = false;
        }
    }

    IEnumerator EventNine()
    {
        eventNineObjects[0].SetActive(true);
        if (eventNineObjects.Length == 2)
        {
            eventNineObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent9)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent9)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventNineObjects[0].SetActive(false);
                if (eventNineObjects.Length == 2)
                {
                    eventNineObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent9 = false;
            }
            else
            {
                cityHealth -= eventLoss;
                eventNineObjects[0].SetActive(false);
                if (eventNineObjects.Length == 2)
                {
                    eventNineObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent9 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventNineObjects[0].SetActive(false);
            if (eventNineObjects.Length == 2)
            {
                eventNineObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent9 = false;
        }
    }

    IEnumerator EventTen()
    {
        eventTenObjects[0].SetActive(true);
        if (eventTenObjects.Length == 2)
        {
            eventTenObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent10)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent10)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventTenObjects[0].SetActive(false);
                if (eventTenObjects.Length == 2)
                {
                    eventTenObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent10 = false;
            }
            else
            {
                cityHealth -= eventLoss;
                eventTenObjects[0].SetActive(false);
                if (eventTenObjects.Length == 2)
                {
                    eventTenObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent10 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventTenObjects[0].SetActive(false);
            if (eventTenObjects.Length == 2)
            {
                eventTenObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent10 = false;
        }
    }

    IEnumerator EventEleven()
    {
        eventElevenObjects[0].SetActive(true);
        if (eventElevenObjects.Length == 2)
        {
            eventElevenObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent11)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent11)
        {
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (FindAnyObjectByType<SkillCheck>().skillCheckActive)
            {
                yield return null;
            }
            if (FindAnyObjectByType<SkillCheck>().skillCheckHit)
            {
                FindAnyObjectByType<SkillCheck>().skillCheckHit = false;
                CityHeal();
                eventElevenObjects[0].SetActive(false);
                if (eventElevenObjects.Length == 2)
                {
                    eventElevenObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent11 = false;
            }
            else
            {
                cityHealth -= eventLoss;
                eventElevenObjects[0].SetActive(false);
                if (eventElevenObjects.Length == 2)
                {
                    eventElevenObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent11 = false;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            eventElevenObjects[0].SetActive(false);
            if (eventElevenObjects.Length == 2)
            {
                eventElevenObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent11 = false;
        }
    }
}
