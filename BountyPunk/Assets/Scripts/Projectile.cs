using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 20f;


    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed*Time.deltaTime;
     
    }

    /* private void OnTriggerEnter(Collider other)
     {
          if (other.gameObject.name == "HouseMesh")
          {
              Destroy(gameObject);
          }
         Debug.Log("hit");
         Destroy(this.gameObject);

             var health = other.gameObject.GetComponent<HealthSystem>();
             if (health)
             {
                 health.DealDamage(damage);
                 Destroy(gameObject);
             }
     }*/

     private void OnCollisionEnter(Collision collision)
     {
        var health = collision.gameObject.GetComponent<HealthSystem>();
       
        if (health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
        
        // Destroy(collision.gameObject);
     }

  /*  private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }*/



}
