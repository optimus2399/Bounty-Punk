using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingMachine : MonoBehaviour
{

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject player;
    [SerializeField] SliderManager slider;
    bool isRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isRange = true;
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isRange = false;
            canvas.SetActive(false);
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
