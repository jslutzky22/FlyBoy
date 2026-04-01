using System.Collections;
using UnityEngine;

public class SkillCheck : MonoBehaviour
{
    [SerializeField] private GameObject hitIndicator;
    [SerializeField] private GameObject successZone;

    void SkillCheckActivate()
    {
        hitIndicator.transform.rotation = new Quaternion(hitIndicator.transform.rotation.x, hitIndicator.transform.rotation.y, 
            Random.Range(0, 360),hitIndicator.transform.rotation.w);
        StartCoroutine(SkillCheckSpin());
    }

    IEnumerator SkillCheckSpin()
    {
        while (true)
        {
            yield return null;
            //hitIndicator.transform.rotation == new Quaternion(hitIndicator.transform.rotation);
        }
    }
}
