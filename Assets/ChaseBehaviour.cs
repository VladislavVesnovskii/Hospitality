using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float chaseSpeed = 3f;
    float attackRange = 2f;
    public static float chaseRange = 10f;
    Granny granny;

    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = chaseSpeed;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        granny = agent.GetComponent<Granny>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            
            agent.SetDestination(player.position);
            float distanse = Vector3.Distance(animator.transform.position, player.position);
            if (distanse < attackRange)
            {
                animator.SetBool("isAttacking", true);
            }
            if (distanse > chaseRange)
            {
                animator.SetBool("isChasing", false);
            }
            if (granny.Health <= 0) animator.SetBool("isDying", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 1.5f;
        chaseRange = 10f;
    }


}
