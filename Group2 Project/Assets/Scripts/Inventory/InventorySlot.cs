using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;//��ϵ� ������ ����
    //public ItemCreate _Item; //�迬�� ���� ������ ����, �Ŀ� ����� �ϳ��� ��ĥ ����. 
    public Image itemImage;//������ �̹��� ��ϵ� �ڸ�
    //public int itemCount;//�ش� ������ ���� ����

    [SerializeField]
    private Text text_Count;
    public void UpdateSlotUI() {
        itemImage.sprite = item.itemImage;
        itemImage.gameObject.SetActive(true);
        text_Count.text = item.itemCount.ToString();
    }
   //public void SlotCount(int Count=1) // Slot�� ������ Item���� ���� �Լ�.
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
