using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleBehavior : StateMachineBehaviour
{
    float timer;
    Transform player;
    //float chaseRange = 10f;
    bool isHide;
    Hide coffin;
    NavMeshAgent agent;
    Vector3 goingPoint;
    bool goingPointIsActive;
    Granny granny;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        coffin = FindObjectOfType<Hide>();
        agent = animator.GetComponent<NavMeshAgent>();
        granny = agent.GetComponent<Granny>();

        EventBus.OnGoingPoint += OnGoingPoint;
        EventBus.OnHide += IsHide;
        isHide = coffin.hideIsShown;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!goingPointIsActive)
        {
            timer += Time.deltaTime;
            if (timer > 10f)
            {
                animator.SetBool("isPatrolling", true);
            }
        }

        if (goingPointIsActive)
        {
            EventBus.goingPointIsActive = true;
            animator.SetBool("isPatrolling", true);

        }
        if (granny.Health <= 0) animator.SetBool("isDying", true);

        if (!isHide)
        {
            float distance = Vector3.Distance(animator.transform.position, player.position);
            if (distance < EventBus.chaseRange)
            {
                animator.SetBool("isChasing", true);
            }
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EventBus.OnGoingPoint -= OnGoingPoint;
        goingPointIsActive = false;
        EventBus.OnHide -= IsHide;
    }

    void OnGoingPoint(Vector3 pointToGo)
    {
        goingPoint = pointToGo;
        goingPointIsActive = true;
    }

    void IsHide(bool hide)
    {
        isHide = hide;
    }
}
