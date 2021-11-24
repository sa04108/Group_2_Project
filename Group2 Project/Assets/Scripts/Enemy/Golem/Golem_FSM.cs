using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_FSM : MonoBehaviour
{
    private Animator animator;
    private MonsterStats monsterStats;
    PlayerStatus playerStatus;

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
    public GameObject Rock;
    public GameObject Hand;
    public GameObject ShootRock;


    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    private int currentTarget;
    private float distanceFromTarget;
    private float preHP;
    private Transform[] waypoints = null;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        monsterStats = gameObject.GetComponent<MonsterStats>();
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();

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

        preHP = monsterStats.HP;
    }

    // Update is called once per frame
    void Update()
    {
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
        AttackSystem();
        GetHit();

    }

    public void ChasePlayer()
    {
        if (currentDistance < 15 && currentDistance > 1)
        {
            navMeshAgent.SetDestination(player.transform.position);
            navMeshAgent.speed = 5;
        }
        else
        {
            navMeshAgent.speed = 2;
        }
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
    void AttackSystem()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
        {
            Rock.transform.position = Hand.transform.position;
            Rock.SetActive(true);
            navMeshAgent.speed = 0;

        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f)
        {

            if(Rock.activeSelf==true)
            {
                //Shoot();
            }
            Rock.SetActive(false);


        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack02"))
        {
            navMeshAgent.speed = 0;

            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.2f
                && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.8f)
                monsterStats.isAttack = true;
            else
                monsterStats.isAttack = false;

        }

    }
    void GetHit()
    {
        if (preHP > monsterStats.HP)
        {
            animator.SetTrigger("Hit");
        }
        else
            return;

        if (monsterStats.HP <= 0)
            monsterStats.isAlive = false;
    }

    void Shoot()
    {
        Instantiate(ShootRock, Rock.transform.position, Rock.transform.rotation);

    }

    /*
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            if (monsterStats.isAttack == true)
            {
                playerStatus.PlayerHP -= monsterStats.AttackPower;
            }
            else
                return;
        }
        else
            return;

    }
    */
}
