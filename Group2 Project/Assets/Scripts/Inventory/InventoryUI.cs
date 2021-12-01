using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{ 
    
    Inventory inven;

    public GameObject inventoryPanel;
    public Sprite nullImage;
    bool isInventoryActive = false;

    public InventorySlot[] slots;
    public Transform slotHolder;
    void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<InventorySlot>();
        inven.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(isInventoryActive);

        RedrawSlotUI();
    }
    void Update()
    {
        RedrawSlotUI();
        if (Input.GetKeyDown(KeyCode.I)) {
            Cursor.visible = !isInventoryActive;
            if (!isInventoryActive)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
            isInventoryActive = !isInventoryActive;
            inventoryPanel.SetActive(isInventoryActive);
        }

    }

    void RedrawSlotUI() {
        foreach(InventorySlot slot in slots) {
            if (slot.item.itemName != "" && slot.item.itemCount == 0) {
                slot.RemoveSlot();
                slot.gameObject.transform.SetAsLastSibling();
            }
        }
        for(int i =0; i<inven.items.Count; i++) {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }
    }
  }

