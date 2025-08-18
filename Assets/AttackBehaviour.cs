using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackBehaviour : StateMachineBehaviour
{
    Transform player;
    float turnSpeed = 2f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = player.position - animator.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        animator.transform.rotation = Quaternion.Lerp(animator.transform.rotation, rotation, turnSpeed*Time.deltaTime);
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance > 3)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
