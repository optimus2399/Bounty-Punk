using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("SetHealth")]
    [SerializeField] float health;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] SliderManager healthBar;

    [Header("Death")]
    [SerializeField] GameObject Death;
    [SerializeField] GameObject deathPos;

    [Header("Blood")]
    [SerializeField] GameObject bloodParticle;
    [SerializeField] GameObject bloodPos;
   
    //Private DataType
    GameManager gameManager;

    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            gameManager.EnemyDie();
            Instantiate(Death, deathPos.transform.position, deathPos.transform.rotation);
        }
    }

   /* private IEnumerator BloodParticle()
    {
        GameObject blood = Instantiate(bloodParticle, bloodPos.transform.position, bloodPos.transform.rotation)as GameObject;
        yield return new WaitForSeconds(1);
        Destroy(blood);
    }*/

}
