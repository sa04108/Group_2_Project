using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    [Header("Monster Stats")]
    public int FullHp = 30;
    public int HP;
    public int AttackPower;
    public bool isAttack = false;



    GameObject player;
    public int P_AttackPower;

    //public GameObject ChicAni; 치킨만 애니메이터가 자식에 붙어있어서 추가한거였습니다.
    public bool isAlive = true; //제대로 못받아와서 몬스터가 안죽음...걍 각 몬스터에 넣었음
    int WeaponPower;

    HUD hud;
    ItemData DB;
    Esder esder;

    void Start()
    {
        hud = FindObjectOfType<HUD>();
        DB = ItemData.instance;
        HP = FullHp;
    }


    void OnTriggerEnter(Collider coll)
    {
        esder = FindObjectOfType<Esder>();
        P_AttackPower = esder.esderP;

        player = GameObject.Find("Player");
        
        //플레이어의 무기에 따라 체력감소
        if (coll.tag == "Arrow")//화살은 isAttack 판별 필요없음.
        {
            Destroy(coll);
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage + P_AttackPower;
            HP -= WeaponPower;
            hud.RenewMonsterHPGauge(this);
            
        }
        else if (coll.tag == "Axe")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_IRON_AXE].damage + P_AttackPower;
            HP -= WeaponPower;
            hud.RenewMonsterHPGauge(this);
        }
        else if (coll.tag == "Dagger")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_SWORD].damage + P_AttackPower;
            HP -= WeaponPower;
            hud.RenewMonsterHPGauge(this);
        }
        else if (coll.tag == "Hammer")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_HAMMER].damage + P_AttackPower;
            HP -= WeaponPower;
            hud.RenewMonsterHPGauge(this);
        }
        else if (coll.tag == "Pickaxe")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_IRON_PICKAXE].damage + P_AttackPower;
            HP -= WeaponPower;
            hud.RenewMonsterHPGauge(this);
        }
    }
}
