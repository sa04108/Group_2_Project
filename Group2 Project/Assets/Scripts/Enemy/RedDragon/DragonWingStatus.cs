using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWingStatus : MonoBehaviour
{

    //드래곤 스테이터스에서 관리하는게 더 편해보이는데 혹시모르니까 둘다 깎음
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
        //날때만 true로 바꿔준다.
        GetComponent<BoxCollider>().enabled = false;
        WingBroken = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //양 날개 체력 각각 50, 한쪽날개 체력이 0이면 더이상 깎이지 않고, 반대쪽 날개를 쏴야 함.
        //양쪽날개에 다른 스크립트 붙여주기 보다 그냥 각 날개 hp=0되면 콜라이더 없애고 wingInjure카운트 올리는게 나을듯
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
        //플레이어의 무기에 따라 체력감소
        if (coll.tag == "Arrow")//화살은 isAttack 판별 필요없음.
        {
            //화살만이 날개에 데미지를 주므로 화살 데미지 받아옴(강화된 보우도 따로 처리해야함)
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage;
            WingHP -= WeaponPower;
            obj.transform.GetChild(0).gameObject.GetComponent<HpBarConnect>().HpToUi(WingHP);




            //날아와 꽂힌 화살 삭제
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
