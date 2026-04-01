using System.Collections;
using UnityEngine;

public class MasterSwatter : MonoBehaviour
{
    [SerializeField] private float swatterEventSystemTimer;
    private int swatterIndex = 0;

    void Start()
    {
        StartCoroutine(SwatterEventSystem());    
    }

    IEnumerator SwatterEventSystem()
    {
        yield return new WaitForSecondsRealtime(swatterEventSystemTimer);
        swatterIndex = Random.Range(0, 6);
        if (swatterIndex == 0)
        {

        }
        else if (swatterIndex == 1)
        {

        }
        else if (swatterIndex == 2)
        {

        }
        else if (swatterIndex == 3)
        {

        }
        else if (swatterIndex == 4)
        {

        }
        else if (swatterIndex == 5)
        {

        }
        else if (swatterIndex == 6)
        {

        }
    }
}
