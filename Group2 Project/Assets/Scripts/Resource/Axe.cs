using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public int Tier;
    [SerializeField]
    private GameObject Player;

    private void Start()
    {
        CraftEquipmentSlot equipSlot;
        equipSlot = CraftEquipmentSlot.instance;
        Tier = equipSlot.slot[CommonDefine.EQUIPMENT_AXE_SLOT_INDEX].equip.equipTier;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wood")&& Player.GetComponent<CharacterAnimator>().isAttack)
        {
            other.GetComponent<Gathering>().Mining(Tier);
        }
    }
}
