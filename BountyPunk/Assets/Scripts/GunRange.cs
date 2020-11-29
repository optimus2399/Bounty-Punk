using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRange : MonoBehaviour
{
    public Loader loader;
    [SerializeField] GameObject pc;
    [SerializeField] GameObject hologram;
    [SerializeField] GameObject holoSpawn;
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
            GameObject holo = Instantiate(hologram, holoSpawn.transform.position,holoSpawn.transform.rotation) as GameObject;
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
