using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
    float timerRate = 30f;
    List<Transform> points = new List<Transform>();
    NavMeshAgent agent;
    bool goingPointIsActive;
    Vector3 goingPoint;
    bool isHide;
    Hide coffin;
    Granny granny;

    Transform player;
    //float chaseRange = 10f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        goingPointIsActive = EventBus.goingPointIsActive;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform t in pointsObject)
        {
            points.Add(t);
        }
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        granny = agent.GetComponent<Granny>();
        EventBus.OnGoingPoint += OnGoingPoint;
        EventBus.OnHide += IsHide;
        coffin = FindObjectOfType<Hide>();
        isHide = coffin.hideIsShown;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!goingPointIsActive) 
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(points[Random.Range(0, points.Count)].position);
            }
            timer += Time.deltaTime;
            if (timer > timerRate)
            {
                animator.SetBool("isPatrolling", false);
            }
        }
        if (goingPointIsActive)
        {
            agent.SetDestination(goingPoint);
            float distanse = Vector3.Distance(animator.transform.position, goingPoint);
            if (distanse <= 2f)
            {
                goingPointIsActive = false;
                animator.SetBool("isPatrolling", false);
            }
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
        agent.SetDestination(agent.transform.position);
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
