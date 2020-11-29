using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public Loader loader;
    [SerializeField] GameObject car;
    [SerializeField] GameObject bountyUI;
    bool inRange = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;  
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }

    private void Load5()
    {
        if (Input.GetKey(KeyCode.E))
        {
            
            car.SetActive(true);
            Time.timeScale = 0;
            bountyUI.SetActive(true);
            loader.Load5();
            
            
        }
    }

    public void ExitUi()
    {
        Time.timeScale = 1;
        bountyUI.SetActive(false);

    }

    private void Update()
    {
        if (inRange)
        {
            Load5();
        }
    }
}
