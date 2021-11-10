using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquip : MonoBehaviour
{
    CraftEquipmentSlot equipments;
    int currentEquipment;
    GameObject currentEquipObject;
    public Transform handTransform;
    // Start is called before the first frame update
    void Start()
    {
        equipments = CraftEquipmentSlot.instance;
        currentEquipment = -1;
    }

    void Update() {
        //1������ ��
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentEquipment != CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX) {
            if(currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_SWORD_SLOT_INDEX;
            currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, handTransform);
        }
        //2������ Ȱ
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentEquipment != CommonDefine.EQUIPMENT_BOW_SLOT_INDEX) {

        }
        //3������ �ظ�
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentEquipment != CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX) {
            if (currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_HAMMER_SLOT_INDEX;
            currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, handTransform);
        }
        //4������ ����
        if (Input.GetKeyDown(KeyCode.Alpha4) && currentEquipment != CommonDefine.EQUIPMENT_AXE_SLOT_INDEX) {
            if (currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_AXE_SLOT_INDEX;
            currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, handTransform);
        }
        //5������ ���
        if (Input.GetKeyDown(KeyCode.Alpha5) && currentEquipment != CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX) {
            if (currentEquipObject != null) {
                Destroy(currentEquipObject);
            }
            currentEquipment = CommonDefine.EQUIPMENT_PICKAXE_SLOT_INDEX;
            currentEquipObject = Instantiate(equipments.slot[currentEquipment].equip.equipPrefab, handTransform);
        }
        //6������ ��ź
        if (Input.GetKeyDown(KeyCode.Alpha6) && currentEquipment != CommonDefine.EQUIPMENT_BOMB_SLOT_INDEX) {

        }
    }
}
