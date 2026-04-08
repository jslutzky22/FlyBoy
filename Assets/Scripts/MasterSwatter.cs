using System.Collections;
using UnityEngine;

public class MasterSwatter : MonoBehaviour
{
    [Header("Main Variables")]
    [SerializeField] private float swatterEventSystemTimer;
    private int swatterIndex = 0;

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
    [SerializeField] private int eventWaitTimer;
    public bool flyBoyMadeItToEvent0;
    public bool flyBoyMadeItToEvent1;
    public bool flyBoyMadeItToEvent2;
    public bool flyBoyMadeItToEvent3;
    public bool flyBoyMadeItToEvent4;
    public bool flyBoyMadeItToEvent5;
    public bool flyBoyMadeItToEvent6;
    [SerializeField] int eventLoss;

    void Start()
    {
        StartCoroutine(SwatterEventSystem());
        cityHealth = 100;
    }

    IEnumerator SwatterEventSystem()
    {
        yield return new WaitForSecondsRealtime(swatterEventSystemTimer);
        swatterIndex = Random.Range(0, 7);
        if (swatterIndex == 0)
        {
            eventActive = true;
            StartCoroutine(EventZero());
        }
        else if (swatterIndex == 1)
        {
            eventActive = true;
            StartCoroutine(EventOne());
        }
        else if (swatterIndex == 2)
        {
            eventActive = true;
            StartCoroutine(EventTwo());
        }
        else if (swatterIndex == 3)
        {
            eventActive = true;
            StartCoroutine(EventThree());
        }
        else if (swatterIndex == 4)
        {
            eventActive = true;
            StartCoroutine(EventFour());
        }
        else if (swatterIndex == 5)
        {
            eventActive = true;
            StartCoroutine(EventFive());
        }
        else if (swatterIndex == 6)
        {
            eventActive = true;
            StartCoroutine(EventSix());
        }
        StartCoroutine(SwatterEventSystem());
    }

    private void CityHeal()
    {
        cityHealth += cityHealAmount;
    }

    IEnumerator EventZero()
    {
        eventZeroObjects[0].SetActive(true);
        if (eventZeroObjects[1] != null)
        { 
            eventZeroObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent0)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
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
                if (eventZeroObjects[1] != null)
                {
                    eventZeroObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent0 = false;
            }
            else 
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= eventLoss;
                eventZeroObjects[0].SetActive(false);
                if (eventZeroObjects[1] != null)
                {
                    eventZeroObjects[1].SetActive(true);
                }
                eventActive = false; 
                flyBoyMadeItToEvent0 = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= eventLoss;
            eventZeroObjects[0].SetActive(false);
            if (eventZeroObjects[1] != null)
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
        if (eventOneObjects[1] != null)
        {
            eventOneObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent1)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
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
                if (eventOneObjects[1] != null)
                {
                    eventOneObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent1 = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= eventLoss;
                eventOneObjects[0].SetActive(false);
                if (eventOneObjects[1] != null)
                {
                    eventOneObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent1 = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= eventLoss;
            eventOneObjects[0].SetActive(false);
            if (eventOneObjects[1] != null)
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
        if (eventTwoObjects[1] != null)
        {
            eventTwoObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent2)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
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
                if (eventTwoObjects[1] != null)
                {
                    eventTwoObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent2 = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= eventLoss;
                eventTwoObjects[0].SetActive(false);
                if (eventTwoObjects[1] != null)
                {
                    eventTwoObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent2 = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= eventLoss;
            eventTwoObjects[0].SetActive(false);
            if (eventTwoObjects[1] != null)
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
        if (eventThreeObjects[1] != null)
        {
            eventThreeObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent3)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
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
                if (eventThreeObjects[1] != null)
                {
                    eventThreeObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent3 = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= eventLoss;
                eventThreeObjects[0].SetActive(false);
                if (eventThreeObjects[1] != null)
                {
                    eventThreeObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent3 = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= eventLoss;
            eventThreeObjects[0].SetActive(false);
            if (eventThreeObjects[1] != null)
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
        if (eventFourObjects[1] != null)
        {
            eventFourObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent4)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
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
                if (eventFourObjects[1] != null)
                {
                    eventFourObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent4 = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= eventLoss;
                eventFourObjects[0].SetActive(false);
                if (eventFourObjects[1] != null)
                {
                    eventFourObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent4 = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= eventLoss;
            eventFourObjects[0].SetActive(false);
            if (eventFourObjects[1] != null)
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
        if (eventFiveObjects[1] != null)
        {
            eventFiveObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent5)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
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
                if (eventFiveObjects[1] != null)
                {
                    eventFiveObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent5 = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= eventLoss;
                eventFiveObjects[0].SetActive(false);
                if (eventFiveObjects[1] != null)
                {
                    eventFiveObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent5 = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= eventLoss;
            eventFiveObjects[0].SetActive(false);
            if (eventFiveObjects[1] != null)
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
        if (eventSixObjects[1] != null)
        {
            eventSixObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent6)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
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
                if (eventSixObjects[1] != null)
                {
                    eventSixObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent6 = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= eventLoss;
                eventSixObjects[0].SetActive(false);
                if (eventSixObjects[1] != null)
                {
                    eventSixObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent6 = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= eventLoss;
            eventSixObjects[0].SetActive(false);
            if (eventSixObjects[1] != null)
            {
                eventSixObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent6 = false;
        }
    }
}
