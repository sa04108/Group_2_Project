using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;//등록될 아이템 정보
    //public ItemCreate _Item; //김연완 버전 아이템 정보, 후에 상담후 하나로 합칠 예정. 
    public Image itemImage;//아이템 이미지 등록될 자리
    //public int itemCount;//해당 아이탬 갯수 스택

    [SerializeField]
    private Text text_Count;
    public void UpdateSlotUI() {
        itemImage.sprite = item.itemImage;
        itemImage.gameObject.SetActive(true);
        text_Count.text = item.itemCount.ToString();
    }
   //public void SlotCount(int Count=1) // Slot에 들어오는 Item들을 세는 함수.
   //{
   //    item.itemCount += Count;
   //    text_Count.text = item.itemCount.ToString();
   //
   //    if (item.itemCount <= 0)
   //        RemoveSlot();
   //}
    public void RemoveSlot() {
        item.itemImage = null;
        item.itemName = "";
        item.itemModel = null;
        item.itemMaterial = null;
        item.itemCount = 0;
    }
}
