using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_FSM : MonoBehaviour
{
    private Animator animator;
    private MonsterStats monsterStats;
    PlayerStatus playerStatus;
    AudioSource audioSource;


    private Ray ray;
    private RaycastHit hit;
    private float maxDistanceToCheck = 10.0f;
    private float currentDistance;
    private Vector3 checkDirection;

    private Transform pointA;
    private Transform pointB;
    private Transform pointC;
    private Transform pointD;

    private GameObject player;

    public GameObject Rock;
    public GameObject Hand;
    public GameObject ShootRock;

    //public AudioClip audioClip;
    //public AudioClip golemSource;


    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    public int currentTarget;
    private float distanceFromTarget;
    private float preHP;
    private float countRock = 0;
    private Transform[] waypoints = null;
    private GameObject insRock;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        monsterStats = gameObject.GetComponent<MonsterStats>();
        player = GameObject.Find("Player").gameObject;
        pointA = GameObject.Find("p1").gameObject.transform;
        pointB = GameObject.Find("p2").gameObject.transform;
        pointC = GameObject.Find("p3").gameObject.transform;
        pointD = GameObject.Find("p4").gameObject.transform;

        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        //audioSource = this.gameObject.GetComponent<AudioSource>();

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
        //GetHit();

        VictoryCheck();
        AliveCheck();

    }

    public void ChasePlayer()
    {
        if (currentDistance < 15 && currentDistance > 1)
        {
            navMeshAgent.SetDestination(player.transform.position);
            navMeshAgent.speed = 5;
            //audioSource.PlayOneShot(audioClip);
        }
        else if (currentDistance < 15 || currentDistance > 1)
        {
            //audioSource.PlayOneShot(golemSource);
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
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
        {
            countRock = 0;


        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
        {
            Rock.transform.position = Hand.transform.position;
            Rock.SetActive(true);
            navMeshAgent.speed = 0;
        }
        
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f)
        {
            Shoot();
            Rock.SetActive(false);

        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack02"))
        {
            navMeshAgent.speed = 0;

            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.2f
                && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.8f)
                monsterStats.isAttack = true;
            

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
        if (1 > countRock && Rock.activeSelf==true)
        {
            monsterStats.isAttack = true;
            insRock = Instantiate(ShootRock, Rock.transform.position, Rock.transform.rotation);
            countRock += 1;
            Destroy(insRock, 0.5f);
            
        }
        
    }

    void AliveCheck()
    {
        if (monsterStats.HP <= 0)
        {
            animator.SetBool("Die", true);
            navMeshAgent.speed = 0;

            Destroy(gameObject, 15.0f);
        }
        else
            return;
    }

    void VictoryCheck()
    {
        if (playerStatus.PlayerHP <= 0)
        {
            navMeshAgent.speed = 0;

            animator.SetBool("PlayerDie", true);
        }
        else
            return;
    }
}
