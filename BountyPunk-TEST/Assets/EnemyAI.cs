using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    Animator anim;
    public GameObject pistol;
    public GameObject bullet;
    public GameObject firePoint;


    public GameObject GetPlayer() { return player; }
    public NavMeshAgent GetAgent() { return agent; }
    public GameObject GetPistol() { return pistol; }
    public GameObject GetBullet() { return bullet; }
    public GameObject GetFirePoint() { return firePoint; }

   public void Fire()
    {
        GameObject projectile = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
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
