using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] GameObject Death;
    [SerializeField] GameObject bloodParticle;
    [SerializeField] GameObject deathPos;
    [SerializeField] GameObject bloodPos;
    [SerializeField] SliderManager healthBar;
    GameManager gameManager;
    // Start is called before the first frame update
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
       // StartCoroutine(BloodParticle());
        if (health <= 0)
        {
            Destroy(gameObject);
            gameManager.EnemyDie();
            Instantiate(Death, deathPos.transform.position, deathPos.transform.rotation);
            
        }
        
    }

    private IEnumerator BloodParticle()
    {
        GameObject blood = Instantiate(bloodParticle, bloodPos.transform.position, bloodPos.transform.rotation)as GameObject;
        yield return new WaitForSeconds(1);
        Destroy(blood);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
