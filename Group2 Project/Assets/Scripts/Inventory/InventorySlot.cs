using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Item item;//��ϵ� ������ ����
    public Image itemImage;//������ �̹��� ��ϵ� �ڸ�
    [SerializeField]
    private Text text_Count;

    public void UpdateSlotUI() {
        itemImage.sprite = item.itemImage;
        itemImage.gameObject.SetActive(true);
        text_Count.text = item.itemCount.ToString();
    }

    public void InitSlot() {
        item.itemImage = null;
        item.itemName = "";
        item.itemModel = null;
        item.itemMaterial = null;
        item.itemCount = 0;
    }
}
