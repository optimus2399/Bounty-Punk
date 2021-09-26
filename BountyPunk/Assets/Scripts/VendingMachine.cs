using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachine : MonoBehaviour
{

    [SerializeField] GameObject vendingMachineCanvas;
    [SerializeField] GameObject barrierCanvas;
    [SerializeField] GameObject player;
    [SerializeField] SliderManager slider;
    bool isRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "VendingMachine")
        {
            if (other.gameObject.tag == "Player")
            {
                isRange = true;
                vendingMachineCanvas.SetActive(true);
            }
        }

        if (this.gameObject.tag == "Barrier")
        {
            if (other.gameObject.tag == "Player")
            {
                barrierCanvas.SetActive(true);
            }
               
        }
     
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == "VendingMachine")
        {
            if (other.gameObject.tag == "Player")
            {
                isRange = false;
                vendingMachineCanvas.SetActive(false);
            }
        }

        if (this.gameObject.tag == "Barrier")
        {
            if (other.gameObject.tag == "Player")
            {
                barrierCanvas.SetActive(false);
            }

        }
    }

    private void Update()
    {
        if (isRange)
        {
            if (Input.GetKey(KeyCode.E))
            {
                player.GetComponent<HealthSystem>().health = player.GetComponent<HealthSystem>().maxHealth;
                slider.SetHealth(player.GetComponent<HealthSystem>().health);
            }
        }
    }
}
