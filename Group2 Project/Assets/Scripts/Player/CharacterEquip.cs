using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquip : MonoBehaviour
{
    Inventory inven;

    CraftEquipmentSlot equipments;
    int currentEquipment;
    
    GameObject currentEquipObject;
    GameObject currentShieldObject;

    public Transform weaponTransform;
    public Transform shieldTransform;
    // Start is called before the first frame update
    void Start()
    {
        inven = Inventory.instance;
        equipments = CraftEquipmentSlot.instance;
        currentEquipment = -1;

        if (inven.shield == true) {
            foreach (Equipment equip in inven.equipments) {
                if (equip.equipType == EQUIP_TYPE.SHIELD) {
                    currentShieldObject = Instantiate(equip.equipPrefab, shieldTransform);
                }
            }
        }
        if (inven.enchantShield == true) {
            Destroy(currentShieldObject);
            foreach (Equipment equip in inven.equipments) {
                if (equip.equipType == EQUIP_TYPE.SHIELD) {
                    currentShieldObject = Instantiate(equip.equipPrefab, shieldTransform);
                }
            }
        }
    }

    void Update() {
        if(currentEquipObject == null) {
            currentEquipment = -1;
        }

        //1¹ø½½·Ô °Ë
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentEquipment != CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX) {
            if(currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX;
            if (equipments.slot[currentEquipment]) {
                currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, weaponTransform);
            }
        }
        //2¹ø½½·Ô È°
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentEquipment != CommonDefine.EQUIPMENT_BOW_SLOT_INDEX) {
            if(currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_BOW_SLOT_INDEX;
            if (equipments.slot[currentEquipment]) {
                currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, weaponTransform);
            }
        }
        //3¹ø½½·Ô ÇØ¸Ó
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentEquipment != CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX) {
            if (currentEquipObject != null) {
                Destroy(currentEquipObject);
            }

            currentEquipment = CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX;

            if (equipments.slot[currentEquipment]) {
                currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, weaponTransform);
            }
        }
        //4¹ø½½·Ô µµ³¢
        if (Input.GetKeyDown(KeyCode.Alpha4) && currentEquipment != CommonDefine.EQUIPMENT_AXE_SLOT_INDEX) {
            if (currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_AXE_SLOT_INDEX;
            if (equipments.slot[currentEquipment]) {
                currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, weaponTransform);
            }
        }
        //5¹ø½½·Ô °î±ªÀÌ
        if (Input.GetKeyDown(KeyCode.Alpha5) && currentEquipment != CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX) {
            if (currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX;
            if (equipments.slot[currentEquipment]) {
                currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, weaponTransform);
            }
        }
        //6¹ø½½·Ô ÆøÅº
        if (Input.GetKeyDown(KeyCode.Alpha6) && currentEquipment != CommonDefine.EQUIPMENT_BOMB_SLOT_INDEX) {
            if(currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_BOMB_SLOT_INDEX;
            if (equipments.slot[currentEquipment]) {
                currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, weaponTransform);
            }
        }
    }
}
