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
        inventoryPanel.SetActive(isInventoryActive);

        RedrawSlotUI();
    }
    void Update()
    {
        RedrawSlotUI();
        if (Input.GetKeyDown(KeyCode.I)) {
 
            isInventoryActive = !isInventoryActive;
            inventoryPanel.SetActive(isInventoryActive);
        }

    }

    void RedrawSlotUI() { 
        foreach(InventorySlot slot in slots) {
            if (slot.item.itemName != "" && slot.item.itemCount == 0) {
                slot.InitSlot();
                //slot.gameObject.transform.SetAsLastSibling();
            }
        }
        for(int i =0; i<inven.items.Count; i++) {
            slots[i].item = inven.CloneItem(inven.items[i]);
            slots[i].UpdateSlotUI();
        }
        for(int i = 0; i<slots.Length; i++) {
            if(i >= inven.items.Count) {
                slots[i].InitSlot();
                slots[i].UpdateSlotUI();
            }
        }
    }
  }

