using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWingStatus : MonoBehaviour
{
    //�巡�� �������ͽ����� �����ϴ°� �� ���غ��̴µ� Ȥ�ø𸣴ϱ� �Ѵ� ����
    [Header("Dragon Wing Stats")]
    public int WingHP = 50;



    DragonStatus dragonStatus;
    private int WeaponPower;
    ItemData DB;

    // Start is called before the first frame update
    void Start()
    {
        dragonStatus = this.transform.root.gameObject.GetComponent<DragonStatus>();
        //������ true�� �ٲ��ش�.
        GetComponent<BoxCollider>().enabled = false;
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
            //ȭ�츸�� ������ �������� �ֹǷ� ȭ�� ������ �޾ƿ�(��ȭ�� ���쵵 ���� ó���ؾ���)
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage;

            
            //�� ���� ü�� ���� 50, ���ʳ��� ü���� 0�̸� ���̻� ������ �ʰ�, �ݴ��� ������ ���� ��.
            if(WingHP >= 0)
            {
                WingHP -= WeaponPower;
                dragonStatus.WingHP -= WeaponPower;
            }
            

            //���ƿ� ���� ȭ�� ����
            Destroy(coll);
        }
    }
    
    public void WingColliderEnabled()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

    public void WingColliderDisableAndReset()
    {
        GetComponent<BoxCollider>().enabled = false;
        WingHP = 50;
    }

}
