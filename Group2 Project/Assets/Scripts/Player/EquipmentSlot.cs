using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Equipment equip;
    public Sprite image;//장비창에 사용할 이미지
    public bool isActive;

    private void Start() {
        isActive = false;
    }

    public void UpdateSlotUI(Equipment _equip) {
        equip = _equip;
        gameObject.GetComponent<Image>().sprite = _equip.equipImage;
        isActive = true;
    }
}
