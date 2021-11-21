using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftEquipmentSlot : MonoBehaviour
{
    public static CraftEquipmentSlot instance;
    private void Awake() {
        instance = this;
    }

    private void Update() {
        RedrawUI();
    }

    void RedrawUI() {
        Inventory inven = Inventory.instance;

        foreach(Equipment _equip in inven.equipments) {
            if(_equip.equipType == EQUIP_TYPE.SWORD) {
                slot[CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX].equip = _equip;
            }
            else if(_equip.equipType == EQUIP_TYPE.BOW) {
                slot[CommonDefine.EQUIPMENT_BOW_SLOT_INDEX].equip = _equip;
            }
            else if(_equip.equipType == EQUIP_TYPE.HAMMER) {
                slot[CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX].equip = _equip;
            }
            else if(_equip.equipType == EQUIP_TYPE.AXE) {
                slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip = _equip;
            }
            else if (_equip.equipType == EQUIP_TYPE.PICKAXE) {
                slot[CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX].equip = _equip;
            }
            else if (_equip.equipType == EQUIP_TYPE.BOMB) {
                slot[CommonDefine.EQUIPMENT_BOMB_SLOT_INDEX].equip = _equip;
            }
        }
    }

    [SerializeField]
    public EquipmentSlot[] slot;
}
