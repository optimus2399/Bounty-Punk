using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRange : MonoBehaviour
{
    public Loader loader;
    [SerializeField] GameObject pc;
    bool inRange = false;
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }

    private void Load4()
    {
        if (Input.GetKey(KeyCode.E))
        {
            loader.Load4();
            pc.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (inRange)
        {
            Load4();
        }
        
    }
}
