using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStatus : MonoBehaviour
{

    [Header("Dragon Stats")]
    public int HP = 1000;
    public int WingHP = 100; //��ȭ�� bow ������ ���, �糯�� 5�뾿

    int WeaponPower;

    ItemData DB;


    // Start is called before the first frame update
    void Start()
    {
        HP = 1000;
        WingHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
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
