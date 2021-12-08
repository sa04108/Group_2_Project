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
        
        //플레이어의 무기에 따라 체력감소
        if (coll.tag == "Arrow")//화살은 isAttack 판별 필요없음.
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
