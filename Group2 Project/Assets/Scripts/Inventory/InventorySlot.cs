using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;//등록될 아이템 정보
    public Image itemImage;//아이템 이미지 등록될 자리

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
