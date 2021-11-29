using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    


    [Header("Dragon's Behavior")]
    //public int DragonHP;
    public bool isFly;
    public bool isLook; //��������
    public bool isChase; //nav�� ����
    public bool isAttack;
    
    


    [Header("rotationSpeed")]//�÷��̾������� ������ �ӵ�
    [SerializeField] float Rotspeed;
    //�÷��̾ �ٶ󺸴°� ����


    [Header("AnimationForce")]
    public float AnimationAddForce = 30.0f;

    Rigidbody rb;

    public float StepBackCD = 5.0f;
    public float StepBackLT = 5.0f;
    public bool isUseSB = false;
    //bool isDie = false;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //������ٵ� ������Ʈ ��������
        animator = GetComponent<Animator>();
        Rotspeed = 5f;
        //DragonHP = 1000;
        isLook = true;
        
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

        if(isFly == true )//&& isWingInjureCount<=2)
        {
            InBattleFly();
        }
        /*
        else if(isFly == true )//&& isWingInjureCount >= 2)
        {
            isFly = false;
            
            //��ġ�� �ǰݸ�� Ʈ���ŷ� �۵�
            //animator.SetTrigger("FlyGetHit");

        }*/
        else
        {
            InBattleWithPlayer();
        }

        




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





    }
    
    //Fly�� �Ÿ��� ���� �ൿ
    public void InBattleFly()
    {

        //�巡�� - �÷��̾� ���� �Ÿ�
        float distance = Vector3.Distance(target.position, transform.position);

        
        if (distance <= 50.0f && distance >= 35f)
        {//�ʹ� �ֱ� ������ fly���·� �̵�
            
        }
        else if (distance <= 35.0f && distance >= 25f)
        {
            //�극��, ���׿� 1:3 ����, ������ �ٰ����鼭 �Ÿ� 20f����

        }
        else if (distance <= 25f && distance >= 13f)
        {
            //�극�� ���׿� 3:1 ����, �ڷ� �������鼭 �Ÿ� 20f����

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
    
    //�ִϸ��̼� �̺�Ʈ�� ȣ��ÿ� �ʿ��� �� ���� ����
    public void ChasePlayer()
    {
        isLook = true;
    }
    public void NoChasePlayer()
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
        GameObject.Find("CanvasDragonWingHp").GetComponent<HpBar>().enabled = true;
        isFly = true;
    }
    public void FlyEnd()
    {
        animator.SetBool("isFly", false);
        GameObject.Find("CanvasDragonWingHp").GetComponent<HpBar>().enabled = false;
        isFly = false;
        GetComponent<DragonStatus>().isWingInjureCount = 0;
    }
}
