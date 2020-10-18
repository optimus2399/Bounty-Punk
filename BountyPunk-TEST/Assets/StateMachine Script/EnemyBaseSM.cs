using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseSM : StateMachineBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public NavMeshAgent agent;
    public GameObject pistol;
    public GameObject bullet;
    public GameObject firePoint;
    public GameObject[] waypoints;
    public float accuracy;
    public float moveSpeed;
    public float rotationSpeed;

    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.gameObject;
        player = enemy.GetComponent<EnemyAI>().GetPlayer();
        agent = enemy.GetComponent<EnemyAI>().GetAgent();
        pistol = enemy.GetComponent<EnemyAI>().GetPistol();
        bullet = enemy.GetComponent<EnemyAI>().GetBullet();
        firePoint = enemy.GetComponent<EnemyAI>().GetFirePoint();
        waypoints = enemy.GetComponent<EnemyAI>().GetWaypoints();
        accuracy = enemy.GetComponent<EnemyAI>().GetAccuracy();
        moveSpeed = enemy.GetComponent<EnemyAI>().GetMoveSpeed();
        rotationSpeed = enemy.GetComponent<EnemyAI>().GetRotationSpeed();
    }

   
}
