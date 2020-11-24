using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public Loader loader;
    [SerializeField] GameObject car;
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
            loader.Load5();
            car.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (inRange)
        {
            Load5();
        }
    }
}
