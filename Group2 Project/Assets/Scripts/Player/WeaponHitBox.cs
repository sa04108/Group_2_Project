using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    public int AttackPower = 5;
    //GameObject HitTheMonster;

    // Start is called before the first frame update
    void Start()
    {
        //isAttack = false;

        //������� �����ϵ��� �����ؾ���
        AttackPower = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //���� ������ ó���� ����
    /*
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "StoneMonster")
        {
            if (isAttack == true)
            {
                CharacterStatus characterStatus = GameObject.Find("Player").GetComponent<CharacterStatus>();
                characterStatus.HP -= AttackPower;
            }

        }

    }
    */
    
}
