using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bossCanvas;
    [SerializeField] GameObject barrier;
 
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bossCanvas.SetActive(true);
            barrier.SetActive(true);
        }
    }

}
