using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillCheck : MonoBehaviour
{
    [SerializeField] private GameObject hitIndicator;
    [SerializeField] private GameObject successZone;
    public bool skillCheckActive;
    private bool hit;
    private bool miss;
    public bool skillCheckHit;

    public void SkillCheckActivate()
    {
        hitIndicator.SetActive(true);
        successZone.SetActive(true);
        skillCheckActive = true;
        successZone.transform.eulerAngles = new Vector4(successZone.transform.eulerAngles.x, successZone.transform.eulerAngles.y, 
            Random.Range(120, 300), successZone.transform.rotation.w);
        hitIndicator.transform.eulerAngles = new Vector4(hitIndicator.transform.eulerAngles.x, hitIndicator.transform.eulerAngles.y, 0, hitIndicator.transform.rotation.w);
        StartCoroutine(SkillCheckSpin());
    }

    IEnumerator SkillCheckSpin()
    {
        while (!hit)
        {
            yield return null;
            hitIndicator.transform.eulerAngles = new Vector4(hitIndicator.transform.eulerAngles.x, hitIndicator.transform.eulerAngles.y,
                hitIndicator.transform.eulerAngles.z + 2, hitIndicator.transform.rotation.w);
            if (miss)
            {
                hitIndicator.GetComponentInChildren<Image>().color = Color.red;
                successZone.GetComponentInChildren<Image>().color = Color.red;
                yield return new WaitForSecondsRealtime(1f);
                hitIndicator.GetComponentInChildren<Image>().color = Color.white;
                successZone.GetComponentInChildren<Image>().color = Color.white;
                miss = false;
            }
        }
        hitIndicator.SetActive(false);
        successZone.SetActive(false);
        hit = false;
        skillCheckHit = true;
        skillCheckActive = false;
    }

    public void OnClick()
    {
        if (hitIndicator.transform.eulerAngles.z > successZone.transform.eulerAngles.z - 26 && 
            hitIndicator.transform.eulerAngles.z < successZone.transform.eulerAngles.z + 26 && skillCheckActive)
        {
            hit = true;
        }
        else if (skillCheckActive)
        {
            miss = true;
        }
    }
}
