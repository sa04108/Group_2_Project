using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonStatus : MonoBehaviour
{
    
    Animator animator;

    public GameObject Lwing;
    public GameObject Rwing;
    public GameObject WingHpBar;

    [Header("Dragon Stats")]
    public int FullHP = 1000;
    public int HP;
    public int WingHP = 100; //강화된 bow 데미지 고려, 양날개 5대씩
    public int isWingInjureCount = 0;
    public int FlyPatternLeft = 2;
    bool isDie = false;
    public bool isFly;

    int WeaponPower;
    public int P_AttackPower;

    HUD hud;
    ItemData DB;
    Rigidbody rb;
    Esder esder;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        DB = ItemData.instance;
        hud = FindObjectOfType<HUD>();

        HP = FullHP;
        WingHP = 100;
        isWingInjureCount = 0;
        FlyPatternLeft = 2;
        isFly = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetInteger("HP", HP);
        if (HP >= 800)
        {

        }
        //날기 패턴 남았고 800이하로 떨어졌을 때 한번 발동
        else if(HP <=800 && HP >=400 &&FlyPatternLeft == 2)
        {
            FlyPatternLeft -= 1;
            animator.SetInteger("FlyPatternLeft", FlyPatternLeft);
            animator.SetTrigger("FlyGetHit");
            animator.SetBool("isFly", true);
            isFly = true;
            
        }
        else if(HP <=800 && HP >= 400 && FlyPatternLeft == 1)
        {

        }
        //날기 패턴 남았고 400이하로 떨어졌을 때 한번 발동
        else if (HP <= 400 && HP > 0 && FlyPatternLeft == 1)
        {
            FlyPatternLeft -= 1;
            animator.SetInteger("FlyPatternLeft", FlyPatternLeft);
            animator.SetTrigger("FlyGetHit");
            animator.SetBool("isFly", true);
            isFly = true;
            
        }
        else if (HP <= 400 && HP > 0 && FlyPatternLeft == 0)
        {

        }
        else if(HP <= 0 && isDie == false)
        {
            isDie = true;
            animator.SetTrigger("isDie");
            Invoke("GameClear", 2f);
        }




        if (isWingInjureCount >= 2)//양쪽 날개 모두 파괴
        {
            //GetComponent<RedControl>().isWingInjure = true;
            
            HP -= 100;
            //체력바 꺼주고
            GameObject.Find("CanvasDragonWingHp").GetComponent<HpBar>().enabled = false;
            

        }


    }

    public void GameClear()
    {
        SceneManager.LoadScene("GameClear");
    }

    public void WingColliderOn()
    {
        Lwing.GetComponent<DragonWingStatus>().WingColliderEnabled();
        Rwing.GetComponent<DragonWingStatus>().WingColliderEnabled();
    }
    public void FlyPatternAdd()
    {
        FlyPatternLeft -= 1;
        animator.SetInteger("FlyPatternLeft", FlyPatternLeft);
    }
    public void WingInjureCountAdd()
    {
        isWingInjureCount += 1;
        animator.SetTrigger("WingInjure");
        animator.SetInteger("WingInjureCount", isWingInjureCount);
        if(isWingInjureCount == 2)
        {
            GameObject wingUI = GameObject.Find("DragonWingHpPrefebs(Clone)");
            Destroy(wingUI);

            //다음 패턴을 위한 초기화
            Lwing.GetComponent<DragonWingStatus>().WingColliderDisableAndReset();
            Rwing.GetComponent<DragonWingStatus>().WingColliderDisableAndReset();
            isWingInjureCount = 0;
            //WingHpBar.GetComponent<HpBar>().removeHpBar();
            //GetComponent<RedControl>().WingHpUI.transform.GetChild(0).gameObject.GetComponent<HpBar>().removeHpBar();
            
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (isFly == false)
        {
            esder = FindObjectOfType<Esder>();
            P_AttackPower = esder.esderP;

            //플레이어의 무기에 따라 체력감소
            if (coll.tag == "Arrow")//화살은 isAttack 판별 필요없음.
            {
                
                P_AttackPower -= 20;
                if(P_AttackPower <= 0)
                {
                    P_AttackPower = 5;
                }
                WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage + P_AttackPower;
                HP -= WeaponPower;
                hud.RenewDragonHPGauge(this);
                Destroy(coll);

            }
            else if (coll.tag == "Axe")
            {
                WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_IRON_AXE].damage + P_AttackPower;
                HP -= WeaponPower;
                hud.RenewDragonHPGauge(this);

            }
            else if (coll.tag == "Dagger")
            {
                WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_SWORD].damage + P_AttackPower;
                HP -= WeaponPower;
                hud.RenewDragonHPGauge(this);

            }
            else if (coll.tag == "Hammer")
            {
                WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_HAMMER].damage + P_AttackPower;
                HP -= WeaponPower;
                hud.RenewDragonHPGauge(this);
            }
            else if (coll.tag == "Pickaxe")
            {
                WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_IRON_PICKAXE].damage + P_AttackPower;
                HP -= WeaponPower;
                hud.RenewDragonHPGauge(this);
            }
            
        }
        
    }

    

}
