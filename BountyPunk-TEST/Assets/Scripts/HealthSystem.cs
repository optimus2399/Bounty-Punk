using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject Death;
    [SerializeField] GameObject deathPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(Death, deathPos.transform.position, deathPos.transform.rotation);
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
