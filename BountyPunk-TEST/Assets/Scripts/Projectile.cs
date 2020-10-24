using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 20f;


    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed;
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "base1")
        {
            Destroy(gameObject);
        }
        
        
            var health = other.gameObject.GetComponent<HealthSystem>();
            if (health)
            {
                health.DealDamage(damage);
                Destroy(gameObject);
            }
        
        
    }


}
