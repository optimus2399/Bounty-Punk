using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    public Loader loader;
    
    private void OnTriggerEnter(Collider other)
    {
        loader.Load6();
        

    }
}
