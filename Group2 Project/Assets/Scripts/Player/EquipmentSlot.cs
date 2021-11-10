using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Equipment equip;
    public Sprite image;//���â�� ����� �̹���
    public bool isActive;

    private void Start() {
        isActive = false;
    }
    private void Update() {
        UpdateSlotUI();
    }

    public void UpdateSlotUI() {
        gameObject.GetComponent<Image>().sprite = equip.equipImage;
        isActive = true;
    }
}
