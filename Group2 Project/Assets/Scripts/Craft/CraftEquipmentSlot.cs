using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftEquipmentSlot : MonoBehaviour
{
    public static CraftEquipmentSlot instance;
    private void Awake() {
        instance = this;
    }
    [SerializeField]
    public EquipmentSlot[] slot;
}
