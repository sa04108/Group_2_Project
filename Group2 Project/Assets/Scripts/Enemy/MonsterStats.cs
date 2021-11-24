using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    [Header("Monster Stats")]
    public int HP = 15;
    public int AttackPower = 2;
    public bool isAttack = false;

    //public GameObject ChicAni; ġŲ�� �ִϸ����Ͱ� �ڽĿ� �پ��־ �߰��Ѱſ����ϴ�.
    public bool isAlive = true; //����� ���޾ƿͼ� ���Ͱ� ������...�� �� ���Ϳ� �־���
    int WeaponPower;

    ItemData DB;

    void Start()
    {
        DB = ItemData.instance;
    }

    void OnTriggerEnter(Collider coll)
    {
        //�÷��̾��� ���⿡ ���� ü�°���
        if (coll.tag == "Arrow")//ȭ���� isAttack �Ǻ� �ʿ����.
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage;
            HP -= WeaponPower;
        }
        else if (coll.tag == "Axe")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_IRON_AXE].damage;
            HP -= WeaponPower;
        }
        else if (coll.tag == "Dagger")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_SWORD].damage;
            HP -= WeaponPower;
        }
        else if (coll.tag == "Hammer")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_HAMMER].damage;
            HP -= WeaponPower;
        }
        else if (coll.tag == "Pickaxe")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_IRON_PICKAXE].damage;
            HP -= WeaponPower;
        }
    }
}
