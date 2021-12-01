using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
public class RedControl : MonoBehaviour
{

    // �÷��̾� �����̵��ÿ��� on
    // �� ������ ������ �־ �׺���̼� �Ѿ��� ��
    // fly�ÿ��� ����� ��


    Animator animator;
    //������ġ
    public Vector3 pos;
    //�i�� ���
    public Transform target;
    //���� hp UI
    public GameObject WingHpUI;
    NavMeshAgent nav;

    [Header("Dragon's Behavior")]
    //public int DragonHP;
    
    public bool isLook; //��������
    public bool isChase; //nav�� ����
    public bool isAttack;
    
    


    [Header("rotationSpeed")]//�÷��̾������� ������ �ӵ�
    [SerializeField] float Rotspeed;
    //�÷��̾ �ٶ󺸴°� ����


    [Header("AnimationForce")]
    public float AnimationAddForce = 350.0f;

    Rigidbody rb;

    public float StepBackCD = 3.5f;
    public float StepBackLT = 3.5f;
    public bool isUseSB = false;
    //bool isDie = false;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //������ٵ� ������Ʈ ��������
        animator = GetComponent<Animator>();
        Rotspeed = 5f;
        //DragonHP = 1000;
        isLook = true;
        nav.isStopped = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        
        //animator.SetInteger("HP", DragonHP);

        //�巡�� ��ų ��Ÿ��
        CoolDownCalculator();

        //Ư�� �ִϸ��̼ǵ����� �÷��̾������� ȸ�� ����. ���߿� ���� �� ��
        if (isLook == true)
        { LookPlayer(); }
        
        
        /*
        else if(isFly == true )//&& isWingInjureCount >= 2)
        {
            isFly = false;
            
            //��ġ�� �ǰݸ�� Ʈ���ŷ� �۵�
            //animator.SetTrigger("FlyGetHit");

        }*/

        
        //InBattleFly();
        
        InBattleWithPlayer();





    }
    public void LookPlayer()
    {
        
        pos = transform.position;
        var rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Rotspeed);
    }
    
    //���󿡼��� �ൿ
    public void InBattleWithPlayer()
    {   //�巡�� - �÷��̾� ���� �Ÿ�
        float distance = Vector3.Distance(target.position, transform.position);
        //�ִϸ��̼ǿ� distance ����
        animator.SetFloat("DistancePlayer", distance);


        /* �ִϸ����Ϳ��� ó���ϴ°� ���ѵ�
        if (distance <= 50.0f && distance >= 35f)
        {
            //�޷����� 

        }
        else if(distance <= 35.0f && distance >= 25f)
        {
            //�극��

        }
        else if(distance <= 25f && distance >= 15f)
        {
            //Ŭ�ξ���
        }
        else if(distance <= 15f && distance >= 10f)
        {
            //�⺻����
        }
        else if (distance <= 10f)
        {
            //stepback ����(15f�� �ڷ� ������ �� �Ϲ�/Ŭ�ΰ���


        }
        */





    }
    
    //Fly�� �Ÿ��� ���� �ൿ
    public void InBattleFly()
    {

        //�巡�� - �÷��̾� ���� �Ÿ�
        float distance = Vector3.Distance(target.position, transform.position);

        
        if (distance <= 50.0f && distance >= 35f)
        {//�ʹ� �ֱ� ������ fly���·� �̵�
            
        }
        else if (distance <= 15f)
        {
            //�÷��̾����� �ڷ� �̵�
        }


    }

    void CoolDownCalculator()
    {
        if (isUseSB == true && StepBackLT > 0)
        {

            StepBackLT -= Time.deltaTime;
            if (StepBackLT < 0)
            {
                //��ٿ� ���� �� �ʱ�ȭ
                StepBackLT = StepBackCD;
                isUseSB = false;
                animator.SetBool("StepBack", false);
            }
        }
    }

    public void StartStepBackCD()
    {
        isUseSB = true;
        animator.SetBool("StepBack", true);
    }

        public void GameEnd()
    {
        /*
        SceneManager.LoadScene("GameOver1");
        Cursor.lockState = CursorLockMode.None;
        //Ŀ�� �����
        Cursor.visible = true;
        */
        
    }

    public void isAttackMouseStart()
    {
        GameObject.Find("UpperMouth02").GetComponent<AttackArea>().Attacking();
        
    }
    public void isAttackMouseStop()
    {
        GameObject.Find("UpperMouth02").gameObject.GetComponent<AttackArea>().StopAttacking();
    }

    public void KnockBack()
    {
        Vector3 reactVector = transform.position - target.position;
        reactVector = reactVector.normalized;
        reactVector += Vector3.up;
        //target.GetComponent<Rigidbody>().AddForce(reactVector * 10, ForceMode.Impulse);
        //rb.AddForce(reactVector*10, ForceMode.Impulse);
        //target.transform.Translate(reactVector*100);
    }

    public void navStart()
    {
        nav.isStopped = false;
        nav.SetDestination(target.position);
        Invoke("navStop", 1.2f);
    }
    public void navStop()
    {
        nav.isStopped = true;
    }
    public void navSpeedUp()
    {
        nav.speed = 18f;

    }
    public void navSpeedReset()
    {
        nav.speed = 10f;
    }
    public void navSpeedZero()
    {
        nav.speed = 0f;
        Invoke("navSpeedReset", 1f);
    }
    public void isAttacking()
    {
        animator.SetBool("isAttack", true);
    }
    public void isAttackEnd()
    {
        animator.SetBool("isAttack", false);
    }
    //�ִϸ��̼� �̺�Ʈ�� ȣ��ÿ� �ʿ��� �� ���� ����
    public void ChasePlayer()
    {
        isLook = true;
    }
    public void ChasePlayerStop()
    {
        isLook = false;
    }

    public void ForceBack()
    {
        //rb.AddForce(orientation.forward.normalized * (-1.0f) * AnimationAddForce, ForceMode.Impulse);
        rb.AddForce(transform.forward.normalized * (-1.0f) * AnimationAddForce, ForceMode.Impulse);
    }

    /*
        if(life <= 0)
        {
            
            Invoke("GameEnd", 15f);
            Player player = GameObject.Find("PlayerFps").GetComponent<Player>();
            

            if(isDie == false)
            {
                animator.SetTrigger("Die");
                isDie = true;

            }


        }*/

    public void FlyStart()
    {
        animator.SetBool("isFly", true);
        //GameObject.Find("CanvasDragonWingHp").GetComponent<HpBar>().enabled = true;
        Instantiate(WingHpUI);
        //isFly = true;
    }
    public void FlyEnd()
    {
        animator.SetBool("isFly", false);
        //GameObject.Find("CanvasDragonWingHp").GetComponent<HpBar>().enabled = false;
        //isFly = false;

        GetComponent<DragonStatus>().isWingInjureCount = 0;
        GetComponent<DragonStatus>().isFly = false;
        animator.SetInteger("WingInjureCount", 0);
    }
    public void DragonDie()
    {
        animator.SetBool("isDieBool", true);
    }
}
