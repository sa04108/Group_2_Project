using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;//등록될 아이템 정보
    public Image itemImage;//아이템 이미지 등록될 자리
    public int itemCount;//해당 아이탬 갯수 스택

    public void UpdateSlotUI() {
        itemImage.sprite = item.itemImage;
        itemImage.gameObject.SetActive(true);
    }
    public void RemoveSlot() {
        item = null;
        itemImage.gameObject.SetActive(false);
    }
}
