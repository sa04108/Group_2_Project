using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class RedControl : MonoBehaviour
{

    // 플레이어 추적이동시에만 on
    // 맵 지형상 엄폐물이 있어서 네비게이션 켜야할 듯
    // fly시에는 꺼줘야 함


    Animator animator;
    //현재위치
    public Vector3 pos;
    //쫒는 대상
    public Transform target;
    //날개 hp UI
    public GameObject WingHpUI;
    NavMeshAgent nav;

    [Header("Dragon's Behavior")]
    //public int DragonHP;
    
    public bool isLook; //고개돌리기
    public bool isChase; //nav로 추적
    public bool isAttack;
    
    


    [Header("rotationSpeed")]//플레이어쪽으로 돌리는 속도
    [SerializeField] float Rotspeed;
    //플레이어를 바라보는가 유무


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
        rb = GetComponent<Rigidbody>(); //리지드바디 컴포넌트 가져오기
        animator = GetComponent<Animator>();
        Rotspeed = 5f;
        //DragonHP = 1000;
        isLook = true;
        nav.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        //animator.SetInteger("HP", DragonHP);

        //드래곤 스킬 쿨타임
        CoolDownCalculator();

        //특정 애니메이션동안은 플레이어쪽으로 회전 안함. 나중에 조건 줄 것
        if (isLook == true)
        { LookPlayer(); }
        
        
        /*
        else if(isFly == true )//&& isWingInjureCount >= 2)
        {
            isFly = false;
            
            //다치는 피격모션 트리거로 작동
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
    
    //지상에서의 행동
    public void InBattleWithPlayer()
    {   //드래곤 - 플레이어 사이 거리
        float distance = Vector3.Distance(target.position, transform.position);
        //애니메이션에 distance 전달
        animator.SetFloat("DistancePlayer", distance);


        /* 애니메이터에서 처리하는게 편한듯
        if (distance <= 50.0f && distance >= 35f)
        {
            //달려가기 

        }
        else if(distance <= 35.0f && distance >= 25f)
        {
            //브레스

        }
        else if(distance <= 25f && distance >= 15f)
        {
            //클로어택
        }
        else if(distance <= 15f && distance >= 10f)
        {
            //기본공격
        }
        else if (distance <= 10f)
        {
            //stepback 실행(15f는 뒤로 물러난 후 일반/클로공격


        }
        */





    }
    
    //Fly시 거리에 따른 행동
    public void InBattleFly()
    {

        //드래곤 - 플레이어 사이 거리
        float distance = Vector3.Distance(target.position, transform.position);

        
        if (distance <= 50.0f && distance >= 35f)
        {//너무 멀기 때문에 fly상태로 이동
            
        }
        else if (distance <= 15f)
        {
            //플레이어피해 뒤로 이동
        }


    }

    void CoolDownCalculator()
    {
        if (isUseSB == true && StepBackLT > 0)
        {

            StepBackLT -= Time.deltaTime;
            if (StepBackLT < 0)
            {
                //쿨다운 끝난 후 초기화
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
        //커서 숨기기
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
    //애니메이션 이벤트로 호출시에 필요할 것 같아 만듦
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
}
