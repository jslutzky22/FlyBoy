using System.Collections;
using UnityEngine;

public class MasterSwatter : MonoBehaviour
{
    [Header("Main Variables")]
    [SerializeField] private float swatterEventSystemTimer;
    private int swatterIndex = 0;
    public bool flyBoyMadeItToEvent;

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

    void Start()
    {
        StartCoroutine(SwatterEventSystem());
        cityHealth = 100;
    }

    IEnumerator SwatterEventSystem()
    {
        yield return new WaitForSecondsRealtime(swatterEventSystemTimer);
        swatterIndex = Random.Range(0, 7);
        if (swatterIndex == 0 && !eventActive)
        {
            eventActive = true;
            StartCoroutine(EventZero());
        }
        else if (swatterIndex == 1 && !eventActive)
        {
            eventActive = true;
            StartCoroutine(EventOne());
        }
        else if (swatterIndex == 2 && !eventActive)
        {
            eventActive = true;
            StartCoroutine(EventTwo());
        }
        else if (swatterIndex == 3 && !eventActive)
        {
            eventActive = true;
            StartCoroutine(EventThree());
        }
        else if (swatterIndex == 4 && !eventActive)
        {
            eventActive = true;
            StartCoroutine(EventFour());
        }
        else if (swatterIndex == 5 && !eventActive)
        {
            eventActive = true;
            StartCoroutine(EventFive());
        }
        else if (swatterIndex == 6 && !eventActive)
        {
            eventActive = true;
            StartCoroutine(EventSix());
        }
        while (!eventActive)
        {

        }
        StartCoroutine(SwatterEventSystem());
    }

    private void CityHeal()
    {
        cityHealth += cityHealAmount;
    }

    IEnumerator EventZero()
    {
        int arrayLength = 0;
        while (arrayLength < eventZeroObjects.Length)
        {
            eventZeroObjects[arrayLength].SetActive(true);
            arrayLength++;
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
        }
        if (flyBoyMadeItToEvent)
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
                arrayLength = 0;
                while (arrayLength < eventZeroObjects.Length)
                {
                    eventZeroObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
            else 
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= 0;
                arrayLength = 0;
                while (arrayLength < eventZeroObjects.Length)
                {
                    eventZeroObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= 0;
            arrayLength = 0;
            while (arrayLength < eventZeroObjects.Length)
            {
                eventZeroObjects[arrayLength].SetActive(false);
                arrayLength++;
            }
            eventActive = false;
        }
    }

    IEnumerator EventOne()
    {
        int arrayLength = 0;
        while (arrayLength < eventOneObjects.Length)
        {
            eventOneObjects[arrayLength].SetActive(true);
            arrayLength++;
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
        }
        if (flyBoyMadeItToEvent)
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
                arrayLength = 0;
                while (arrayLength < eventOneObjects.Length)
                {
                    eventOneObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= 0;
                arrayLength = 0;
                while (arrayLength < eventOneObjects.Length)
                {
                    eventOneObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= 0;
            arrayLength = 0;
            while (arrayLength < eventOneObjects.Length)
            {
                eventOneObjects[arrayLength].SetActive(false);
                arrayLength++;
            }
            eventActive = false;
        }
    }

    IEnumerator EventTwo()
    {
        int arrayLength = 0;
        while (arrayLength < eventTwoObjects.Length)
        {
            eventTwoObjects[arrayLength].SetActive(true);
            arrayLength++;
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
        }
        if (flyBoyMadeItToEvent)
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
                arrayLength = 0;
                while (arrayLength < eventTwoObjects.Length)
                {
                    eventTwoObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= 0;
                arrayLength = 0;
                while (arrayLength < eventTwoObjects.Length)
                {
                    eventTwoObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= 0;
            arrayLength = 0;
            while (arrayLength < eventTwoObjects.Length)
            {
                eventTwoObjects[arrayLength].SetActive(false);
                arrayLength++;
            }
            eventActive = false;
        }
    }

    IEnumerator EventThree()
    {
        int arrayLength = 0;
        while (arrayLength < eventThreeObjects.Length)
        {
            eventThreeObjects[arrayLength].SetActive(true);
            arrayLength++;
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
        }
        if (flyBoyMadeItToEvent)
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
                arrayLength = 0;
                while (arrayLength < eventThreeObjects.Length)
                {
                    eventThreeObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= 0;
                arrayLength = 0;
                while (arrayLength < eventThreeObjects.Length)
                {
                    eventThreeObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= 0;
            arrayLength = 0;
            while (arrayLength < eventThreeObjects.Length)
            {
                eventThreeObjects[arrayLength].SetActive(false);
                arrayLength++;
            }
            eventActive = false;
        }
    }

    IEnumerator EventFour()
    {
        int arrayLength = 0;
        while (arrayLength < eventFourObjects.Length)
        {
            eventFourObjects[arrayLength].SetActive(true);
            arrayLength++;
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
        }
        if (flyBoyMadeItToEvent)
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
                arrayLength = 0;
                while (arrayLength < eventFourObjects.Length)
                {
                    eventFourObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= 0;
                arrayLength = 0;
                while (arrayLength < eventFourObjects.Length)
                {
                    eventFourObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= 0;
            arrayLength = 0;
            while (arrayLength < eventFourObjects.Length)
            {
                eventFourObjects[arrayLength].SetActive(false);
                arrayLength++;
            }
            eventActive = false;
        }
    }

    IEnumerator EventFive()
    {
        int arrayLength = 0;
        while (arrayLength < eventFiveObjects.Length)
        {
            eventFiveObjects[arrayLength].SetActive(true);
            arrayLength++;
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
        }
        if (flyBoyMadeItToEvent)
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
                arrayLength = 0;
                while (arrayLength < eventFiveObjects.Length)
                {
                    eventFiveObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= 0;
                arrayLength = 0;
                while (arrayLength < eventFiveObjects.Length)
                {
                    eventFiveObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= 0;
            arrayLength = 0;
            while (arrayLength < eventFiveObjects.Length)
            {
                eventFiveObjects[arrayLength].SetActive(false);
                arrayLength++;
            }
            eventActive = false;
        }
    }

    IEnumerator EventSix()
    {
        int arrayLength = 0;
        while (arrayLength < eventSixObjects.Length)
        {
            eventSixObjects[arrayLength].SetActive(true);
            arrayLength++;
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer--;
        }
        if (flyBoyMadeItToEvent)
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
                arrayLength = 0;
                while (arrayLength < eventSixObjects.Length)
                {
                    eventSixObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
            else
            {
                //insert a value here, i just don't know what to put yet
                cityHealth -= 0;
                arrayLength = 0;
                while (arrayLength < eventSixObjects.Length)
                {
                    eventSixObjects[arrayLength].SetActive(false);
                    arrayLength++;
                }
                eventActive = false;
            }
        }
        else
        {
            //insert a value here, i just don't know what to put yet
            cityHealth -= 0;
            arrayLength = 0;
            while (arrayLength < eventSixObjects.Length)
            {
                eventSixObjects[arrayLength].SetActive(false);
                arrayLength++;
            }
            eventActive = false;
        }
    }
}
