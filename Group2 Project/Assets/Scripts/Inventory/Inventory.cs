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


    public Item CloneItem(Item itemRef) {
        Item _item = new Item();
        _item.itemCount = itemRef.itemCount;
        _item.itemImage = itemRef.itemImage;
        _item.itemMaterial = itemRef.itemMaterial;
        _item.itemModel = itemRef.itemModel;
        _item.itemName = itemRef.itemName;
        _item.itemType = itemRef.itemType;

        return _item;
    }

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
                for (int i = 0; i < items.Count; i++) {
                    if (items[i].itemCount == 0) {
                        items[i] = _item;
                        return true;
                    }
                }
                items.Add(_item);
            }
            return true;
        }
        return false;
    }



    public Equipment SearchEquipment(EQUIP_TYPE type) {
        foreach(Equipment equip in equipments){
            if(equip.equipType == type) {
                return equip; 
            }
        }
        return null;
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

    public bool CheckItem(string itemName)
    {
        foreach (Item content in items)
        {
            if (itemName == content.itemName)
            {
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
