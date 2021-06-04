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
    Animator anim;
    public GameObject pistol;
    public GameObject bullet;
    public GameObject firePoint;
    public GameObject[] waypoints;
    Rigidbody rb;
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
        if (Physics.Raycast(firePoint.transform.position, firePoint.transform.right, out hit,shootRange))
        {
            if(hit.transform.tag == "Player")
            {
                hit.transform.GetComponent<HealthSystem>().DealDamage(enemyDamage);
            }
        }
        //GameObject projectile = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }
    public void StopFiring()
    {
        CancelInvoke("Fire");
    }
    // Start is called before the first frame update

    private void Awake()
    {
        //waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Distance", Vector3.Distance(transform.position, player.transform.position));
    }
}
