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

    //public GameObject ChicAni; ġŲ�� �ִϸ����Ͱ� �ڽĿ� �پ��־ �߰��Ѱſ����ϴ�.
    public bool isAlive = true; //����� ���޾ƿͼ� ���Ͱ� ������...�� �� ���Ϳ� �־���
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
        
        //�÷��̾��� ���⿡ ���� ü�°���
        if (coll.tag == "Arrow")//ȭ���� isAttack �Ǻ� �ʿ����.
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
