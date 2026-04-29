using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MasterSwatter : MonoBehaviour
{
    public static MasterSwatter instance;

    [Header("Main Variables")]
    [SerializeField] private float swatterEventSystemTimer;
    private int swatterIndex = 0;
    private int lastEvent;
    [SerializeField] GameObject approvalRating;
    [SerializeField] GameObject swatterAppears;
    [SerializeField] TMP_Text swatterText;
    [SerializeField] GameObject pauseUI;
    [SerializeField] private bool tutorialLevel;
    [SerializeField] public bool floatingRing;

    [Header("City Health")]
    public int cityHealth;
    [SerializeField] private int cityHealAmount;

    [Header("Events")]
    private bool eventActive;
    [SerializeField] private int swatterPopUpLengthInSeconds = 10;
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
    [SerializeField] private Slider[] eventTimerVisuals;
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

    [Header("SwatterText")]
    [SerializeField] private string event0Text;
    [SerializeField] private string event1Text;
    [SerializeField] private string event2Text;
    [SerializeField] private string event3Text;
    [SerializeField] private string event4Text;
    [SerializeField] private string event5Text;
    [SerializeField] private string event6Text;
    [SerializeField] private string event7Text;
    [SerializeField] private string event8Text;
    [SerializeField] private string event9Text;
    [SerializeField] private string event10Text;
    [SerializeField] private string event11Text;

    [Header("AudioClips")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip swatterPopUpSound;
    [SerializeField] private AudioClip swatterComplete;
    [SerializeField] private AudioClip swatterFail;
    [SerializeField] private AudioClip event0Audio;
    [SerializeField] private AudioClip event1Audio;
    [SerializeField] private AudioClip event2Audio;
    [SerializeField] private AudioClip event3Audio;
    [SerializeField] private AudioClip event4Audio;
    [SerializeField] private AudioClip event5Audio;
    [SerializeField] private AudioClip event6Audio;
    [SerializeField] private AudioClip event7Audio;
    [SerializeField] private AudioClip event8Audio;
    [SerializeField] private AudioClip event9Audio;
    [SerializeField] private AudioClip event10Audio;
    [SerializeField] private AudioClip event11Audio;

    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < eventTimerVisuals.Length; i++)
        {
            eventTimerVisuals[i].maxValue = eventWaitTimer;
        }

        StartCoroutine(SwatterEventSystem());
        cityHealth = 100;
    }

    private void Update()
    {
        if (cityHealth <= 0 && !tutorialLevel)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    IEnumerator SwatterEventSystem()
    {
        float timer = swatterEventSystemTimer;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        swatterIndex = Random.Range(0, 12);
        while (swatterIndex == lastEvent)
        {
            swatterIndex = Random.Range(0, 12);
        }
        lastEvent = swatterIndex;
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
            swatterText.text = event0Text + "";
        }
        else if (swatterIndex == 1)
        {
            swatterText.text = event1Text + "";
        }
        else if (swatterIndex == 2)
        {
            swatterText.text = event2Text + "";
        }
        else if (swatterIndex == 3)
        {
            swatterText.text = event3Text + "";
        }
        else if (swatterIndex == 4)
        {
            swatterText.text = event4Text + "";
        }
        else if (swatterIndex == 5)
        {
            swatterText.text = event5Text + "";
        }
        else if (swatterIndex == 6)
        {
            swatterText.text = event6Text + "";
        }
        else if (swatterIndex == 7)
        {
            swatterText.text = event7Text + "";
        }
        else if (swatterIndex == 8)
        {
            swatterText.text = event8Text + "";
        }
        else if (swatterIndex == 9)
        {
            swatterText.text = event9Text + "";
        }
        else if (swatterIndex == 10)
        {
            swatterText.text = event10Text + "";
        }
        else if (swatterIndex == 11)
        {
            swatterText.text = event11Text + "";
        }
        int timer2 = swatterPopUpLengthInSeconds;
        while (timer2 > 0)
        {
            yield return new WaitForSeconds(1);
            timer2--;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        swatterAppears.SetActive(false);
        audioSource.PlayOneShot(swatterPopUpSound);
        approvalRating.SetActive(true);
    }

    private void CityHeal()
    {
        audioSource.PlayOneShot(swatterComplete);
        cityHealth += cityHealAmount;
        cityHealth = Mathf.Min(cityHealth, 100);
    }

    IEnumerator EventZero()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event0Audio);
        eventZeroObjects[0].SetActive(true);
        if (eventZeroObjects.Length == 2)
        { 
            eventZeroObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent0)
        {
            yield return new WaitForSeconds(1f);   
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[0].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent0)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else 
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventZeroObjects[0].SetActive(false);
                if (eventZeroObjects.Length == 2)
                {
                    eventZeroObjects[1].SetActive(true);
                }
                eventActive = false; 
                flyBoyMadeItToEvent0 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventZeroObjects[0].SetActive(false);
            if (eventZeroObjects.Length == 2)
            {
                eventZeroObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent0 = false;
        }
        ArrowPoint.instance.HideArrow();
    }

    IEnumerator EventOne()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event1Audio);
        eventOneObjects[0].SetActive(true);
        if (eventOneObjects.Length == 2)
        {
            eventOneObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent1)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[1].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent1)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventOneObjects[0].SetActive(false);
                if (eventOneObjects.Length == 2)
                {
                    eventOneObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent1 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventOneObjects[0].SetActive(false);
            if (eventOneObjects.Length == 2)
            {
                eventOneObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent1 = false;
        }
        ArrowPoint.instance.HideArrow();
    }

    IEnumerator EventTwo()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event2Audio);
        eventTwoObjects[0].SetActive(true);
        if (eventTwoObjects.Length == 2)
        {
            eventTwoObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent2)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[2].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent2)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventTwoObjects[0].SetActive(false);
                if (eventTwoObjects.Length == 2)
                {
                    eventTwoObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent2 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventTwoObjects[0].SetActive(false);
            if (eventTwoObjects.Length == 2)
            {
                eventTwoObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent2 = false;
        }
        ArrowPoint.instance.HideArrow();
    }

    IEnumerator EventThree()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event3Audio);
        eventThreeObjects[0].SetActive(true);
        if (eventThreeObjects.Length == 2)
        {
            eventThreeObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent3)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[3].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent3)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventThreeObjects[0].SetActive(false);
                if (eventThreeObjects.Length == 2)
                {
                    eventThreeObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent3 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventThreeObjects[0].SetActive(false);
            if (eventThreeObjects.Length == 2)
            {
                eventThreeObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent3 = false;
        }
        ArrowPoint.instance.HideArrow();
    }

    IEnumerator EventFour()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event4Audio);
        eventFourObjects[0].SetActive(true);
        if (eventFourObjects.Length == 2)
        {
            eventFourObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent4)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[4].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent4)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventFourObjects[0].SetActive(false);
                if (eventFourObjects.Length == 2)
                {
                    eventFourObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent4 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventFourObjects[0].SetActive(false);
            if (eventFourObjects.Length == 2)
            {
                eventFourObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent4 = false;
        }
        ArrowPoint.instance.HideArrow();
    }

    IEnumerator EventFive()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event5Audio);
        eventFiveObjects[0].SetActive(true);
        if (eventFiveObjects.Length == 2)
        {
            eventFiveObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent5)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[5].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent5)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventFiveObjects[0].SetActive(false);
                if (eventFiveObjects.Length == 2)
                {
                    eventFiveObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent5 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventFiveObjects[0].SetActive(false);
            if (eventFiveObjects.Length == 2)
            {
                eventFiveObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent5 = false;
        }
        ArrowPoint.instance.HideArrow();
    }

    IEnumerator EventSix()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event6Audio);
        eventSixObjects[0].SetActive(true);
        if (eventSixObjects.Length == 2)
        {
            eventSixObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent6)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[6].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent6)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventSixObjects[0].SetActive(false);
                if (eventSixObjects.Length == 2)
                {
                    eventSixObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent6 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventSixObjects[0].SetActive(false);
            if (eventSixObjects.Length == 2)
            {
                eventSixObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent6 = false;
        }
        ArrowPoint.instance.HideArrow();
    }

    IEnumerator EventSeven()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event7Audio);
        eventSevenObjects[0].SetActive(true);
        if (eventSevenObjects.Length == 2)
        {
            eventSevenObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent7)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[7].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent7)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventSevenObjects[0].SetActive(false);
                if (eventSevenObjects.Length == 2)
                {
                    eventSevenObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent7 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventSevenObjects[0].SetActive(false);
            if (eventSevenObjects.Length == 2)
            {
                eventSevenObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent7 = false;
        }
        ArrowPoint.instance.HideArrow();
    }

    IEnumerator EventEight()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event8Audio);
        eventEightObjects[0].SetActive(true);
        if (eventEightObjects.Length == 2)
        {
            eventEightObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent8)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[8].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent8)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventEightObjects[0].SetActive(false);
                if (eventEightObjects.Length == 2)
                {
                    eventEightObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent8 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventEightObjects[0].SetActive(false);
            if (eventEightObjects.Length == 2)
            {
                eventEightObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent8 = false;
        }
        ArrowPoint.instance.HideArrow();
    }

    IEnumerator EventNine()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event9Audio);
        eventNineObjects[0].SetActive(true);
        if (eventNineObjects.Length == 2)
        {
            eventNineObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent9)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[9].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent9)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventNineObjects[0].SetActive(false);
                if (eventNineObjects.Length == 2)
                {
                    eventNineObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent9 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventNineObjects[0].SetActive(false);
            if (eventNineObjects.Length == 2)
            {
                eventNineObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent9 = false;
        }
        ArrowPoint.instance.HideArrow();
    }

    IEnumerator EventTen()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event10Audio);
        eventTenObjects[0].SetActive(true);
        if (eventTenObjects.Length == 2)
        {
            eventTenObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent10)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[10].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent10)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventTenObjects[0].SetActive(false);
                if (eventTenObjects.Length == 2)
                {
                    eventTenObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent10 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventTenObjects[0].SetActive(false);
            if (eventTenObjects.Length == 2)
            {
                eventTenObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent10 = false;
        }
        ArrowPoint.instance.HideArrow();
    }

    IEnumerator EventEleven()
    {
        audioSource.PlayOneShot(swatterPopUpSound);
        audioSource.PlayOneShot(event11Audio);
        eventElevenObjects[0].SetActive(true);
        if (eventElevenObjects.Length == 2)
        {
            eventElevenObjects[1].SetActive(false);
        }
        int timer = eventWaitTimer;
        while (timer > 0 && !flyBoyMadeItToEvent11)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (floatingRing)
            {
                timer += 2;
                floatingRing = false;
            }
            eventTimerVisuals[11].value = timer;
            while (pauseUI.activeSelf == true)
            {
                yield return null;
            }
        }
        if (flyBoyMadeItToEvent11)
        {
            FindFirstObjectByType<FlyingController>().moveSpeed = 0;
            FindAnyObjectByType<SkillCheck>().SkillCheckActivate();
            while (SkillCheck.skillCheckActive)
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
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
            else
            {
                cityHealth -= eventLoss;
                audioSource.PlayOneShot(swatterFail);
                eventElevenObjects[0].SetActive(false);
                if (eventElevenObjects.Length == 2)
                {
                    eventElevenObjects[1].SetActive(true);
                }
                eventActive = false;
                flyBoyMadeItToEvent11 = false;
                FindFirstObjectByType<FlyingController>().moveSpeed = 15;
            }
        }
        else
        {
            cityHealth -= eventLoss;
            audioSource.PlayOneShot(swatterFail);
            eventElevenObjects[0].SetActive(false);
            if (eventElevenObjects.Length == 2)
            {
                eventElevenObjects[1].SetActive(true);
            }
            eventActive = false;
            flyBoyMadeItToEvent11 = false;
        }
        ArrowPoint.instance.HideArrow();
    }
}
