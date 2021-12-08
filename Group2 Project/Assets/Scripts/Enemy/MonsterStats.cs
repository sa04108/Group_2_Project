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
    CraftEquipmentSlot equipSlots;
    Esder esder;

    void Start()
    {
        equipSlots = CraftEquipmentSlot.instance;
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
            WeaponPower = equipSlots.slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].equip.damage + P_AttackPower;
            HP -= WeaponPower;
            hud.RenewMonsterHPGauge(this);
            
        }
        else if (coll.tag == "Axe")
        {
            WeaponPower = equipSlots.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip.damage + P_AttackPower;
            HP -= WeaponPower;
            hud.RenewMonsterHPGauge(this);
        }
        else if (coll.tag == "Dagger")
        {
            WeaponPower = equipSlots.slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].equip.damage + P_AttackPower;
            Debug.Log(WeaponPower);
            HP -= WeaponPower;
            hud.RenewMonsterHPGauge(this);
        }
        else if (coll.tag == "Hammer")
        {
            WeaponPower = equipSlots.slot[CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX].equip.damage + P_AttackPower;
            HP -= WeaponPower;
            hud.RenewMonsterHPGauge(this);
        }
        else if (coll.tag == "Pickaxe")
        {
            WeaponPower = equipSlots.slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].equip.damage + P_AttackPower;
            HP -= WeaponPower;
            hud.RenewMonsterHPGauge(this);
        }
    }
}
