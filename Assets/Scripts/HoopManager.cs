using System.Collections;
using UnityEngine;

public class HoopManager : MonoBehaviour
{
    [SerializeField] private GameObject[] hoops;
    [SerializeField] private float timeBetweenHoopsSpawning;
    [SerializeField] public GameObject[] deliveryPoints;

    void Start()
    {
        StartCoroutine(hoopSpawner());
    }

    IEnumerator hoopSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenHoopsSpawning);
            int randomNumber = Random.Range(0, hoops.Length);
            hoops[randomNumber].SetActive(true);
        }
    }
}
