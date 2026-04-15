using TMPro;
using UnityEngine;

public class ApprovalRatingUI : MonoBehaviour
{
    [SerializeField] private RectTransform dial;
    [SerializeField] private TMP_Text percentage;

    private void Update()
    {
        switch (MasterSwatter.instance.cityHealth)
        {
            case (<= 20):
                dial.rotation = Quaternion.Euler(0, 0, 70);
                break;
            case (<= 40):
                dial.rotation = Quaternion.Euler(0, 0, 35);
                break;
            case (<= 60):
                dial.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case (<= 80):
                dial.rotation = Quaternion.Euler(0, 0, -35);
                break;
            case (> 80):
                dial.rotation = Quaternion.Euler(0, 0, -70);
                break;
        }

        percentage.text = MasterSwatter.instance.cityHealth + "%";
    }
}
