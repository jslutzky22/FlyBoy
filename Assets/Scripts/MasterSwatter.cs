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
        int arrayLength = 0;
        while (arrayLength < eventZeroObjects.Length)
        {
            eventZeroObjects[arrayLength].SetActive(true);
            arrayLength++;
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
