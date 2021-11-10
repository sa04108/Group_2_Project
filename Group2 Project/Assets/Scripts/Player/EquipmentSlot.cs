using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Item item;
    public Sprite image;//���â�� ����� �̹���
    public int tier; // Tool or Weapon�� ���

    public void UpdateSlotUI(Item _item) {
        gameObject.GetComponent<Image>().sprite = _item.itemImage;
        
    }
    // ���â�� ���� ������ �������� �׿� �´� Tier�� �о�ͼ� ���⸦ ���� ��Ű�� ������ ������ ��.
    // ex) ��� 1��° ĭ�� ������ 'Į' -> EquipmentSlot[1].Tier = 1�̸� sword�� tier = 1 -> ���߿� ����� �ɷ�ġ ����.
}
