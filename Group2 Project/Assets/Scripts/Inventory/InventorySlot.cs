using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;//��ϵ� ������ ����
    //public ItemCreate _Item; //�迬�� ���� ������ ����, �Ŀ� ����� �ϳ��� ��ĥ ����. 
    public Image itemImage;//������ �̹��� ��ϵ� �ڸ�
    public int itemCount;//�ش� ������ ���� ����

    [SerializeField]
    private Text text_Count;

    public void UpdateSlotUI() {
        itemImage.sprite = item.itemImage;
        itemImage.gameObject.SetActive(true);
    }
    public void SlotCount(int Count=1) // Slot�� ������ Item���� ���� �Լ�.
    {
        itemCount += Count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            RemoveSlot();
    }
    public void RemoveSlot() {
        item = null;
        itemCount = 0;
        itemImage.gameObject.SetActive(false);
    }
}
