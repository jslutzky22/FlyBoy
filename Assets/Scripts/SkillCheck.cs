using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SkillCheck : MonoBehaviour
{
    [SerializeField] private GameObject hitIndicator;
    [SerializeField] private GameObject successZone;
    public bool skillCheckActive;
    private bool hit;
    public bool skillCheckHit;

    public void SkillCheckActivate()
    {
        hitIndicator.SetActive(true);
        successZone.SetActive(true);
        skillCheckActive = true;
        successZone.transform.eulerAngles = new Vector4(successZone.transform.eulerAngles.x, successZone.transform.eulerAngles.y, 
            Random.Range(0, 360), successZone.transform.rotation.w);
        StartCoroutine(SkillCheckSpin());
    }

    IEnumerator SkillCheckSpin()
    {
        float timer = 10;
        while (timer > 0 && !hit)
        {
            timer -= Time.deltaTime;
            yield return null;
            hitIndicator.transform.eulerAngles = new Vector4(hitIndicator.transform.eulerAngles.x, hitIndicator.transform.eulerAngles.y,
                hitIndicator.transform.eulerAngles.z + 1, hitIndicator.transform.rotation.w);
        }
        if (hit)
        {
            hitIndicator.SetActive(false);
            successZone.SetActive(false);
            hit = false;
            skillCheckHit = true;
            skillCheckActive = false;
        }
        else
        {
            hitIndicator.SetActive(false);
            successZone.SetActive(false);
            skillCheckHit = false;
            skillCheckActive = false;
        }
    }

    void OnClick()
    {
        Debug.Log("click");
        if (hitIndicator.transform.eulerAngles.z > successZone.transform.eulerAngles.z - 26 && 
            hitIndicator.transform.eulerAngles.z < successZone.transform.eulerAngles.z + 26 && skillCheckActive)
        {
            hit = true;
        }
    }
}
