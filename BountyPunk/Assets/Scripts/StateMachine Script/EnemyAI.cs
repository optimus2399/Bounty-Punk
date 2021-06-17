using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    [Header("Refrences")]
    public GameObject player;
    public NavMeshAgent agent;
    
    [Header("Gun")]
    public GameObject pistol;
    public GameObject bullet;
    public GameObject firePoint;
    public GameObject ray;
    public GameObject lineRender;
    public AudioClip shootSFX;
    [Range(0, 1)] public float shootSFXVolume;

    public GameObject[] waypoints;

    //Private DataType
    Rigidbody rb;
    Animator anim;
    RaycastHit hit = new RaycastHit();
  
    

    [Header("AI Settings")]

    public float accuracy = 2f;
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float enemyDamage = 10;
    public float shootRange = 5f;
    
    public GameObject GetPlayer() { return player; }
    public NavMeshAgent GetAgent() { return agent; }
    public GameObject GetPistol() { return pistol; }
    public GameObject GetBullet() { return bullet; }
    public GameObject GetFirePoint() { return firePoint; }
    public float GetMoveSpeed() { return moveSpeed; }
    public float GetAccuracy() { return accuracy; }
    public float GetRotationSpeed() { return rotationSpeed; }
    public GameObject[] GetWaypoints() { return waypoints; }
    public Rigidbody GetRigidBody() { return rb; }

   public void Fire()
    {
        if (Physics.Raycast(ray.transform.position, ray.transform.right, out hit,shootRange))
        {
            
            if(hit.transform.tag == "Player")
            {
                hit.transform.GetComponent<HealthSystem>().DealDamage(enemyDamage);
            }
        }      
    }

    public void LineRenderer()
    {
        Instantiate(bullet, lineRender.transform.position, lineRender.transform.rotation);
        AudioSource.PlayClipAtPoint(shootSFX, transform.position, shootSFXVolume);
    }

    public void StartSpray()
    {
        InvokeRepeating("LineRenderer", 0.5f, 0.5f);
    }

    public void StopSpray()
    {
        CancelInvoke("LineRenderer");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }
    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Distance", Vector3.Distance(transform.position, player.transform.position));
    }
}
