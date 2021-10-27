using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventory;
    bool isInventoryActive = false;

    public InventorySlot[] slots;
    public Transform slotHolder;
    void Start()
    {
        slots = slotHolder.GetComponentsInChildren<InventorySlot>();
        inventory.SetActive(isInventoryActive);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            isInventoryActive = !isInventoryActive;
            inventory.SetActive(isInventoryActive);
        }
    }
}
