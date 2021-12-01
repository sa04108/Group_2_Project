using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake() {
        DontDestroyOnLoad(gameObject);
      if (instance != null) {
          Destroy(gameObject);
          return;
      }
        instance = this;
    }
    #endregion

   //public delegate void OnSlotCountChange(int val);
   //public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    private int slotCnt;

    public int SlotCnt {
        get => slotCnt;
        set {
            slotCnt = value;
        }
    }


    void Start() {
        SlotCnt = 10;
    }

    public List<Item> items = new List<Item>();
    public List<Equipment> equipments = new List<Equipment>();
    public bool shield = false;
    public bool enchantShield = false;
    public void AddEquip(Equipment _equip) {
        foreach(Equipment content in equipments) {
            if(_equip.equipType == content.equipType) {
                equipments.Remove(content);
                equipments.Add(_equip);
                return;
            }
        }
        equipments.Add(_equip);
    }
    public bool AddItem(Item _item) {
        if(items.Count < SlotCnt) {
            if (!CheckItemList(_item)) {
                items.Add(_item);
            }
            return true;
        }
        return false;
    }

    public bool CheckItemList(Item _item) {
        foreach(Item content in items) {
            if(_item.itemName == content.itemName) {
                content.itemCount += _item.itemCount;
                return true;
            }
        }
        return false;
    }

    public bool IsFull() {
        if(items.Count >= SlotCnt) {
            return true;
        }
        return false;
    }

}
