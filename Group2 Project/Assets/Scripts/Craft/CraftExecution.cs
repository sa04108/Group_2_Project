using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftExecution : MonoBehaviour
{
    private Inventory inven;
    public Item item; // 요구되는 자원의 item 정보
    [SerializeField]
    private int RequestCount;// 요구되는 item의 수
    [SerializeField]
    private int EquipmentNum;// 담당할 slot의 숫자
    [SerializeField]
    private Sprite EquipmentImage; // 장비창에 들어갈 이미지

    private void Start()
    {
        inven = Inventory.instance;
    }

    public void Crafting() // Craft 버튼을 눌렀을 경우.
    {
        for (int i = 0; i < inven.SlotCnt; i++)
        {
            // 슬롯을 전부 검사해서 필요한 아이템 이름 == 인벤토리에 있는 아이템 이름이 있는지 확인. ( item.Name string 이용 )
            // 만일 확인이 되었다면 필요한 아이템의 수 <= 인벤토리의 아이템 수를 비교, 확인.
            // 전부 완료 되었다면, 인벤토리에 있는 아이템의 수 -= 필요한 아이템의 수.
            // EquipmentSlot에 해당하는 Slot 참조하여 안의 내용을 갱신, 이미지 변환. or Player의 Equipment의 데이터를 갱신
        }
    }
}
