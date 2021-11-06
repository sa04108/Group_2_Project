using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{ 
    // 11/6 김연완 55번째 줄 수정. 우현이형 보신다면 확인 후 필요하시다면 처리 부탁드립니다.
    Inventory inven;

    public GameObject inventoryPanel;
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
            for(int i = 0; i<slots.Length; i++) {
            slots[i].RemoveSlot();
        }
            for(int i =0; i<inven.items.Count; i++) {
            slots[i].item = inven.items[i];
            //slots[i].UpdateSlotUI();      updateslot이 아이템 먹을때 작동하는건지 잘 모르겠습니당.
        }
    }

    public void AcqureItem(Item _item, int Count=1)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item.itemName == "")
            {
                GameObject SlotText = slots[i].transform.GetChild(1).gameObject;
                SlotText.SetActive(true);
                slots[i].UpdateSlotUI(_item);
                return;
            }
        }
        for (int i=0;i<slots.Length;i++)
        {
            if(slots[i].item.itemName == _item.itemName)
            {
                slots[i].SlotCount(Count);
                return;
            }
        }
    }
  }

