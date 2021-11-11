using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public static EquipmentUI instance;
    public Transform slotHolder;
    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    [SerializeField]
    public EquipmentSlot[] slot;

    private void Start() {
        slot = slotHolder.GetComponentsInChildren<EquipmentSlot>();
    }
}
