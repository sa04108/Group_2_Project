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
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(isInventoryActive);
    }

    private void SlotChange(int val) {
        for(int i=0; i<slots.Length; i++) {
            if (i < inven.SlotCnt) {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }
    public void AddSlot() {
        inven.SlotCnt++;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {

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

