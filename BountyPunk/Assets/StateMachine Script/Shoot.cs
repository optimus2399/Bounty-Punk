using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : EnemyBaseSM
{
    GameObject gun;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        base.OnStateEnter(animator, stateInfo, layerIndex);
        gun = Instantiate(pistol, firePoint.transform.position, firePoint.transform.rotation) as GameObject;
        gun.transform.SetParent(firePoint.transform);
        enemy.GetComponent<EnemyAI>().StartFiring();
        agent.speed = 0f;
        agent.stoppingDistance = 4f;
        agent.acceleration = 20f;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var direction = player.transform.position - enemy.transform.position;
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime);
        
        gun.transform.position = firePoint.transform.position;
        gun.transform.rotation = firePoint.transform.rotation;
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.GetComponent<EnemyAI>().StopFiring();
        Destroy(gun);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
