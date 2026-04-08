using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FlyBoy")
        {
            if (gameObject.name == "Event0Trigger")
            {
                FindFirstObjectByType<MasterSwatter>().flyBoyMadeItToEvent0 = true;
            }
            if (gameObject.name == "Event1Trigger")
            {
                FindFirstObjectByType<MasterSwatter>().flyBoyMadeItToEvent1 = true;
            }
            if (gameObject.name == "Event2Trigger")
            {
                FindFirstObjectByType<MasterSwatter>().flyBoyMadeItToEvent2 = true;
            }
            if (gameObject.name == "Event3Trigger")
            {
                FindFirstObjectByType<MasterSwatter>().flyBoyMadeItToEvent3 = true;
            }
            if (gameObject.name == "Event4Trigger")
            {
                FindFirstObjectByType<MasterSwatter>().flyBoyMadeItToEvent4 = true;
            }
            if (gameObject.name == "Event5Trigger")
            {
                FindFirstObjectByType<MasterSwatter>().flyBoyMadeItToEvent5 = true;
            }
            if (gameObject.name == "Event6Trigger")
            {
                FindFirstObjectByType<MasterSwatter>().flyBoyMadeItToEvent6 = true;
            }
        }
    }
}
