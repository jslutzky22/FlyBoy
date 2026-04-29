using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExitClick()
    {
        tutorial.SetActive(false);
    }
}
