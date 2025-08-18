using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoctorChaseBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float chaseSpeed = 0.8f;
    public static float chaseRange = 5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = GameObject.FindGameObjectWithTag("Doctor").GetComponent<NavMeshAgent>();
        agent.GetComponent<AudioSource>().Play();
        agent.speed = chaseSpeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float distanse = Vector3.Distance(animator.transform.position, player.position);
        if (distanse > chaseRange)
        {
            animator.SetBool("isChasing", false);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 0.5f;
        chaseRange = 5f;
    }
}
