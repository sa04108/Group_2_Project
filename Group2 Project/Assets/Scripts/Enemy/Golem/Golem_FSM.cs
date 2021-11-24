using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_FSM : MonoBehaviour
{
    private Animator animator;
    private Ray ray;
    private RaycastHit hit;
    private float maxDistanceToCheck = 10.0f;
    private float currentDistance;
    private Vector3 checkDirection;

    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public GameObject player;

    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    private int currentTarget;
    private float distanceFromTarget;
    private Transform[] waypoints = null;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        pointA = GameObject.Find("p1").transform;
        pointB = GameObject.Find("p2").transform;
        pointC = GameObject.Find("p3").transform;
        pointD = GameObject.Find("p4").transform;

        navMeshAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        waypoints = new Transform[4] {
            pointA,
            pointB,
            pointC,
            pointD
        };
        currentTarget = 0;
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pointA);

        navMeshAgent.SetDestination(waypoints[currentTarget].position);


        currentDistance = Vector3.Distance(player.transform.position, transform.position);
        animator.SetFloat("PlayerDistance", currentDistance);

        checkDirection = player.transform.position - transform.position;
        ray = new Ray(transform.position, checkDirection);
        if (Physics.Raycast(ray, out hit, maxDistanceToCheck))
        {

            if (hit.collider.gameObject == player)
            {
                animator.SetBool("isPlayerVisible", true);
            }
            else
            {
                animator.SetBool("isPlayerVisible", false);
            }
        }
        else
        {
            animator.SetBool("isPlayerVisible", false);
        }

        distanceFromTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position);
        animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
        ChasePlayer();
        Attack();
        
    }

    public void ChasePlayer()
    {
        if (currentDistance < 10 && currentDistance > 6)
        {
            navMeshAgent.SetDestination(player.transform.position);
            navMeshAgent.speed = 5;
        }
        else
        {
            navMeshAgent.speed = 2;
        }
    }

    public void Attack()
    {
        if (currentDistance < 6 && currentDistance > 1)
        {
            navMeshAgent.SetDestination(player.transform.position);
            navMeshAgent.speed = 0;
        }
        else
            return;
    }


    public void SetNextPoint()
    {

        switch (currentTarget)
        {
            case 0:
                currentTarget = 1;
                break;
            case 1:
                currentTarget = 2;
                break;
            case 2:
                currentTarget = 3;
                break;
            case 3:
                currentTarget = 0;
                break;
        }
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }
}
