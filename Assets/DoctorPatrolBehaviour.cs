using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class DoctorPatrolBehaviour : StateMachineBehaviour
{
    List<Transform> points = new List<Transform>();
    NavMeshAgent agent;
    bool goingPointIsActive;
    Vector3 goingPoint;
    bool isHide;
    Hide coffin;

    Transform player;
    public float chaseRange = 5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        goingPointIsActive = EventBus.goingPointIsActive;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points2").transform;
        foreach (Transform t in pointsObject)
        {
            points.Add(t);
        }
        agent = GameObject.FindGameObjectWithTag("Doctor").GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EventBus.OnGoingPoint += OnGoingPoint;
        EventBus.OnHide += IsHide;
        coffin = FindObjectOfType<Hide>();
        isHide = coffin.hideIsShown;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!goingPointIsActive)
        {
            if (agent.remainingDistance <= 1)
            {
                agent.SetDestination(points[Random.Range(0, points.Count)].position);
            }
        }

        if (!isHide)
        {
            float distance = Vector3.Distance(animator.transform.position, player.position);
            if (distance < chaseRange)
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
