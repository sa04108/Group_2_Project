
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoarCtrl : MonoBehaviour
{

    //네비매쉬 쓸거라 점프해도 안올라감. 애니메이션으로 대체
    //[SerializeField] float jumpForce = 15f;
    [SerializeField] float timeBeforeNextJump = 1.2f;
    [SerializeField] Vector3 pos;
    [SerializeField] float distance;
    //[SerializeField] bool isDie = false;
    public Vector3 BoarPos;

    [SerializeField] float canJump = 0f;
    [SerializeField] bool isFindPlayer;

    //네비게이션 추적
    Transform target;
    NavMeshAgent nav;
    Vector3 destination;


    [SerializeField] AudioClip targetOnSound;
    AudioSource audio;


    [Header("Monster Stats")]
    //public int HP = 30;
    //public int AttackPower = 10;
    //public bool isAttack = false;
    //GameObject AttackHead;
    bool isAlive = true;
    GameObject AttackHead;
    bool isRun = false;



    [Header("Patrol and Regen Point")]
    //패트롤 포인트 저장
    public Transform[] points;
    public Transform PatrolPoint;
    public int nextIdx = 1;
    public float speed = 3f;
    private bool isWalk = false;
    //회전
    public float damping = 3.5f;

    private Transform tr;

    Animator animator;
    Rigidbody rb;
    [SerializeField]
    private GameObject ItemDrop;
    [SerializeField]
    private GameObject HealingPotion;



    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();

        target = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //패트롤 포인트 들고오기
        tr = GetComponent<Transform>();
        //points = GameObject.Find("RegenPoint").GetComponentsInChildren<Transform>();
        //루트에서 자식으로 패트롤 포인트 찾게 변경
        points = PatrolPoint.GetComponentsInChildren<Transform>();

        isFindPlayer = false;
        //AttackHead = transform.GetChild(0).GetCompontnt<AttackArea>();
        //AttackHead = transform.GetChild(0).GetComponentInChilderen<AttackArea>();
        AttackHead = transform.GetChild(1).gameObject;

    }
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //isAlive = GetComponent<MonsterStats>().isAlive;
        if (isAlive == true)
        {
            float distance = Vector3.Distance(target.position, transform.position);


            if (distance <= 17.0f && distance >= 2.8f)
            {
                //탐색 범위 안에 들어왔을때 닭 울음소리
                if (isFindPlayer == false) {
                    audio.clip = targetOnSound;
                    audio.Play();
                }

                isFindPlayer = true;
                nav.isStopped = false;
                nav.SetDestination(target.position);
                animator.SetTrigger("Run");
                if (isRun == false)
                {
                    isRun = true;
                    nav.speed = 7.0f;
                }
                //보자마자 돌진
                AttackHead.GetComponent<AttackArea>().isAttack = true;
            }
            else if (distance < 2.8f)
            {
                nav.isStopped = true;
                rb.velocity = Vector3.zero;
                if (isRun == true)
                {
                    animator.SetTrigger("Horn Attack");
                    isRun = false;
                    nav.speed = 3.5f;
                }
                animator.SetTrigger("Basic Attack");


                AttackHead.GetComponent<AttackArea>().isAttack = true;

                LookPlayer();
            }
            else if (distance > 17.0f && isFindPlayer == true)
            {
                nav.speed = 3.5f;
                //추적 중지
                nav.isStopped = true;
                //애니메이션 걷기 중지
                //animator.SetInteger("Walk", 0);
                animator.SetTrigger("Walk");
                //관성제거
                rb.velocity = Vector3.zero;
                //플레이어 못찾음
                isFindPlayer = false;
                //공격상태 false유지
                AttackHead.GetComponent<AttackArea>().isAttack = false;

            }

            if (isFindPlayer == false)
            {
                //현재 ~ 가야 할 위치의 벡터 
                animator.SetTrigger("Walk");
                Quaternion rot = Quaternion.LookRotation(points[nextIdx].position - tr.position);
                //다음 가야 할 지점까지 회전
                tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
                tr.Translate(Vector3.forward * Time.deltaTime * speed);

            }

        }

        int HP = GetComponent<MonsterStats>().HP;
        if (HP <= 0)
        {
            if (isAlive == true)
            {
                animator.SetTrigger("Die");
                isAlive = false;
                Invoke("itemDrop", 1.7f);
                transform.parent.gameObject.GetComponent<ErasePatrol>().EraseThis();

            }
        }
    }

    void itemDrop()
    {
        GameObject dropItem = Instantiate(ItemDrop, transform.position, Quaternion.identity);
        dropItem.GetComponent<DropItem>().SetItem(ItemData.instance.itemDB[CommonDefine.RESOURCE_UNSTABLE_CORE]);

        dropItem = Instantiate(ItemDrop, transform.position, Quaternion.identity);
        dropItem.GetComponent<DropItem>().SetItem(ItemData.instance.itemDB[CommonDefine.RESOURCE_ENCHANT_STONE]);
        //Instantiate(rockItemDrop, transform.position, Quaternion.identity);



        //50%확률로 드랍
        int RandomNum = Random.Range(1, 10);
        if (RandomNum < 6)
        {
            GameObject dropItem2 = Instantiate(HealingPotion, transform.position, Quaternion.identity);
            dropItem2.GetComponent<DropItem>().SetItem(ItemData.instance.itemDB[CommonDefine.ITEM_HEAL_POTION]);
        }

    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "PatrolPoint")
        {
            if (isWalk == false)
            {
                isWalk = true;
                animator.SetTrigger("Walk");
            }
            //패트롤포인트 증가시키다가 끝이면 첫번쨰로
            nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
            canJump = Time.time + timeBeforeNextJump;

        }
        /*
        if (coll.tag == "basicWeapon")
        {

            if (GameObject.Find("Player").GetComponent<CharacterAnimator>().isAttack == true)
            {
                HP = HP - coll.gameObject.GetComponent<WeaponHitBox>().AttackPower;
                GameObject.Find("Player").GetComponent<CharacterAnimator>().isAttack = false;

            }
        }
        */
    }
    public void LookPlayer()
    {

        pos = transform.position;
        var rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
    }
    /*
    void Update()
    {

        pos = this.transform.position;

        //타겟(플레이어)의 포지션을 목표지점으로


        if (distance <= 5.0f && distance >= 1.5f)
        {
            nav.SetDestination(target.position);

            animator.SetInteger("Walk", 1);
            Debug.Log("in 5 m");
        }

        else if (distance < 1.5f)
        {
            //공격범위 안에 들어왔을 때 정지
            nav.isStopped = true;
            animator.SetTrigger("Attack");
        }
        else if(Vector3.Distance(destination, target.position) > 5f)
        {
            //타겟 추적 중지
            nav.enabled = false;
            animator.SetInteger("Walk", 0);
            //anim.SetTrigger("jump");
        }
    }
    //점프용
                rb.AddForce(0, jumpForce, 0);
                canJump = Time.time + timeBeforeNextJump;
                anim.SetTrigger("jump");
    */
}
