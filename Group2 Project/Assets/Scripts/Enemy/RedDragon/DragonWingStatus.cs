using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWingStatus : MonoBehaviour
{

    //�巡�� �������ͽ����� �����ϴ°� �� ���غ��̴µ� Ȥ�ø𸣴ϱ� �Ѵ� ����
    [Header("Dragon Wing Stats")]
    public int WingHP;
    public bool WingBroken;
    bool isFly = false;

    public GameObject obj;
    DragonStatus dragonStatus;
    private int WeaponPower;
    ItemData DB;

    // Start is called before the first frame update
    void Start()
    {
        DB = ItemData.instance;
        WingHP = 80;
        dragonStatus = this.transform.root.gameObject.GetComponent<DragonStatus>();
        //������ true�� �ٲ��ش�.
        GetComponent<BoxCollider>().enabled = false;
        WingBroken = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //�� ���� ü�� ���� 50, ���ʳ��� ü���� 0�̸� ���̻� ������ �ʰ�, �ݴ��� ������ ���� ��.
        //���ʳ����� �ٸ� ��ũ��Ʈ �ٿ��ֱ� ���� �׳� �� ���� hp=0�Ǹ� �ݶ��̴� ���ְ� wingInjureī��Ʈ �ø��°� ������
        if (WingHP <= 0 && WingBroken == false)
        {
            WingBroken = true;
            //WingHP -= WeaponPower;
            //dragonStatus.WingHP -= WeaponPower;
            GetComponent<BoxCollider>().enabled = false;

            dragonStatus.WingInjureCountAdd();
            
        }
        else if (WingHP >= 0)
        {
            
            //dragonStatus.WingHP -= WeaponPower;
        }

        
    }

    void OnTriggerEnter(Collider coll)
    {
        //�÷��̾��� ���⿡ ���� ü�°���
        if (coll.tag == "Arrow")//ȭ���� isAttack �Ǻ� �ʿ����.
        {
            //ȭ�츸�� ������ �������� �ֹǷ� ȭ�� ������ �޾ƿ�(��ȭ�� ���쵵 ���� ó���ؾ���)
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage;
            WingHP -= WeaponPower;
            obj.transform.GetChild(0).gameObject.GetComponent<HpBarConnect>().HpToUi(WingHP);




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
        WingHP = 80;
        WingBroken = false;
    }

}
