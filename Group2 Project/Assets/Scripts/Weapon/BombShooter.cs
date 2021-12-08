using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShooter : MonoBehaviour
{
    Inventory inven;
    CraftEquipmentSlot equipSlots;
    public GameObject bomb;

    const float delay = 2.0f;
    bool isReady;

    private void Start()
    {
        equipSlots = CraftEquipmentSlot.instance;
        inven = Inventory.instance;
        isReady = true;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1") && isReady) {
            StartCoroutine(Shoot());
            //ÆøÅº °³¼ö Â÷°¨ ¹× Ã¼Å©
            CheckBombStat();
        }   
    }
    
    void CheckBombStat() {
        Equipment bomb = inven.SearchEquipment(EQUIP_TYPE.BOMB);

        bomb.durability -= 1;

        if (bomb.durability == 0) {
            Debug.Log("bomb durability is 0!");
            inven.equipments.Remove(bomb);
            equipSlots.slot[CommonDefine.EQUIPMENT_BOMB_SLOT_INDEX].InitSlot();
            equipSlots.slot[CommonDefine.EQUIPMENT_BOMB_SLOT_INDEX].UpdateSlotUI();
            Destroy(gameObject);
            
        }
    }

    IEnumerator Shoot()
    {
        Destroy(Instantiate(bomb, transform.parent.position, Quaternion.LookRotation(Camera.main.transform.forward)), 3.0f);
        isReady = false;

        yield return new WaitForSeconds(delay);
        isReady = true;
    }
}
