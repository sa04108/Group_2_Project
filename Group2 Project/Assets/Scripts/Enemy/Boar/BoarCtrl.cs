
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoarCtrl : MonoBehaviour
{

    //�׺�Ž� ���Ŷ� �����ص� �ȿö�. �ִϸ��̼����� ��ü
    //[SerializeField] float jumpForce = 15f;
    [SerializeField] float timeBeforeNextJump = 1.2f;
    [SerializeField] Vector3 pos;
    [SerializeField] float distance;
    //[SerializeField] bool isDie = false;
    public Vector3 BoarPos;

    [SerializeField] float canJump = 0f;
    [SerializeField] bool isFindPlayer;

    //�׺���̼� ����
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
    //��Ʈ�� ����Ʈ ����
    public Transform[] points;
    public Transform PatrolPoint;
    public int nextIdx = 1;
    public float speed = 3f;
    private bool isWalk = false;
    //ȸ��
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
        //��Ʈ�� ����Ʈ ������
        tr = GetComponent<Transform>();
        //points = GameObject.Find("RegenPoint").GetComponentsInChildren<Transform>();
        //��Ʈ���� �ڽ����� ��Ʈ�� ����Ʈ ã�� ����
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
                //Ž�� ���� �ȿ� �������� �� �����Ҹ�
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
                //���ڸ��� ����
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
                //���� ����
                nav.isStopped = true;
                //�ִϸ��̼� �ȱ� ����
                //animator.SetInteger("Walk", 0);
                animator.SetTrigger("Walk");
                //��������
                rb.velocity = Vector3.zero;
                //�÷��̾� ��ã��
                isFindPlayer = false;
                //���ݻ��� false����
                AttackHead.GetComponent<AttackArea>().isAttack = false;

            }

            if (isFindPlayer == false)
            {
                //���� ~ ���� �� ��ġ�� ���� 
                animator.SetTrigger("Walk");
                Quaternion rot = Quaternion.LookRotation(points[nextIdx].position - tr.position);
                //���� ���� �� �������� ȸ��
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



        //50%Ȯ���� ���
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
            //��Ʈ������Ʈ ������Ű�ٰ� ���̸� ù������
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

        //Ÿ��(�÷��̾�)�� �������� ��ǥ��������


        if (distance <= 5.0f && distance >= 1.5f)
        {
            nav.SetDestination(target.position);

            animator.SetInteger("Walk", 1);
            Debug.Log("in 5 m");
        }

        else if (distance < 1.5f)
        {
            //���ݹ��� �ȿ� ������ �� ����
            nav.isStopped = true;
            animator.SetTrigger("Attack");
        }
        else if(Vector3.Distance(destination, target.position) > 5f)
        {
            //Ÿ�� ���� ����
            nav.enabled = false;
            animator.SetInteger("Walk", 0);
            //anim.SetTrigger("jump");
        }
    }
    //������
                rb.AddForce(0, jumpForce, 0);
                canJump = Time.time + timeBeforeNextJump;
                anim.SetTrigger("jump");
    */
}
