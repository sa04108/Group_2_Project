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

        //1������ ��
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentEquipment != CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX) {
            if(currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX;
            if (equipments.slot[currentEquipment]) {
                currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, weaponTransform);
            }
        }
        //2������ Ȱ
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentEquipment != CommonDefine.EQUIPMENT_BOW_SLOT_INDEX) {
            if(currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_BOW_SLOT_INDEX;
            if (equipments.slot[currentEquipment]) {
                currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, weaponTransform);
            }
        }
        //3������ �ظ�
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentEquipment != CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX) {
            if (currentEquipObject != null) {
                Destroy(currentEquipObject);
            }

            currentEquipment = CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX;

            if (equipments.slot[currentEquipment]) {
                currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, weaponTransform);
            }
        }
        //4������ ����
        if (Input.GetKeyDown(KeyCode.Alpha4) && currentEquipment != CommonDefine.EQUIPMENT_AXE_SLOT_INDEX) {
            if (currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_AXE_SLOT_INDEX;
            if (equipments.slot[currentEquipment]) {
                currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, weaponTransform);
            }
        }
        //5������ ���
        if (Input.GetKeyDown(KeyCode.Alpha5) && currentEquipment != CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX) {
            if (currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX;
            if (equipments.slot[currentEquipment]) {
                currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, weaponTransform);
            }
        }
        //6������ ��ź
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
