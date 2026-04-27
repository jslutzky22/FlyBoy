using System.Collections;
using UnityEngine;

public class HoopManager : MonoBehaviour
{
    [SerializeField] private GameObject[] hoops;
    [SerializeField] private float timeBetweenHoopsSpawning;

    void Start()
    {
        StartCoroutine(hoopSpawner());
    }

    IEnumerator hoopSpawner()
    {
        yield return new WaitForSeconds(timeBetweenHoopsSpawning);
        int randomNumber = Random.Range(0, hoops.Length);
        hoops[randomNumber].SetActive(true);
    }
}
