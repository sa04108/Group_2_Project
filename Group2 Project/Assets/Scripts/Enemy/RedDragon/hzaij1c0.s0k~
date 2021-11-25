using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWingStatus : MonoBehaviour
{
    //드래곤 스테이터스에서 관리하는게 더 편해보이는데 혹시모르니까 둘다 깎음
    [Header("Dragon Wing Stats")]
    public int WingHP = 50;



    DragonStatus dragonStatus;
    private int WeaponPower;
    ItemData DB;

    // Start is called before the first frame update
    void Start()
    {
        dragonStatus = this.transform.root.gameObject.GetComponent<DragonStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter(Collider coll)
    {
        //플레이어의 무기에 따라 체력감소
        if (coll.tag == "Arrow")//화살은 isAttack 판별 필요없음.
        {
            //화살만이 날개에 데미지를 주므로 화살 데미지 받아옴(강화된 보우도 따로 처리해야함)
            WeaponPower = DB.equipDB[CommonDefine.EQUIPMENT_BOW].damage;

            
            //양 날개 체력 각각 50, 한쪽날개 체력이 0이면 더이상 깎이지 않고, 반대쪽 날개를 쏴야 함.
            if(WingHP >= 0)
            {
                WingHP -= WeaponPower;
                dragonStatus.WingHP -= WeaponPower;
            }
            

            //날아와 꽂힌 화살 삭제
            Destroy(coll);
        }
    }
    


}
