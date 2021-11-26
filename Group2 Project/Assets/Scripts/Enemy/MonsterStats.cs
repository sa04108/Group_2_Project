using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    [Header("Monster Stats")]
    public int HP = 15;
    public int AttackPower;
    public bool isAttack = false;



    GameObject player;
    public int P_AttackPower;

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

        player = GameObject.Find("Player");
        P_AttackPower = player.GetComponent<PlayerStatus>().AttackPower;
        Debug.Log(P_AttackPower);
        //�÷��̾��� ���⿡ ���� ü�°���
        if (coll.tag == "Arrow")//ȭ���� isAttack �Ǻ� �ʿ����.
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage + P_AttackPower;
            HP -= WeaponPower;
        }
        else if (coll.tag == "Axe")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage + P_AttackPower;
            HP -= WeaponPower;
        }
        else if (coll.tag == "Dagger")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage + P_AttackPower;
            HP -= WeaponPower;
        }
        else if (coll.tag == "Hammer")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage + P_AttackPower;
            HP -= WeaponPower;
        }
        else if (coll.tag == "Pickaxe")
        {
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage + P_AttackPower;
            HP -= WeaponPower;
        }
    }
}
