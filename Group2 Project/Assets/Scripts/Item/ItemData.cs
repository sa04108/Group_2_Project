using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static ItemData instance;
    private void Awake() {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public List<Item> itemDB = new List<Item>();

    public List<Equipment> equipDB = new List<Equipment>();

    public GameObject fieldItemPrefab;

    public Vector3[] pos;

    public Item CloneItem(int index) {
        Item itemRef = itemDB[index];
        Item _item = new Item();
        _item.itemCount = itemRef.itemCount;
        _item.itemImage = itemRef.itemImage;
        _item.itemMaterial = itemRef.itemMaterial;
        _item.itemModel = itemRef.itemModel;
        _item.itemName = itemRef.itemName;
        _item.itemType = itemRef.itemType;

        return _item;
    }

    public Equipment CloneEquip(int index) {
        Equipment equipRef = equipDB[index];
        Equipment _equip = new Equipment();

        _equip.equipImage = equipRef.equipImage;
        _equip.equipName = equipRef.equipName;
        _equip.equipPrefab = equipRef.equipPrefab;
        _equip.equipTier = equipRef.equipTier;
        _equip.equipType = equipRef.equipType;
        _equip.damage = equipRef.damage;
        _equip.durability = equipRef.durability;
        _equip.loggingPower = equipRef.loggingPower;
        _equip.miningPower = equipRef.miningPower;

        return _equip;
    }

    private void Start() {

        // GameObject go = Instantiate(fieldItemPrefab, new Vector3 (266f, 21f, 70f), Quaternion.identity);
        // go.GetComponent<DropItem>().SetItem(itemDB[0]);
        //GameObject go2 = Instantiate(fieldItemPrefab, new Vector3(263f, 21f, 76f), Quaternion.identity);
        //go2.GetComponent<DropItem>().SetItem(itemDB[1]);
        //GameObject go3 = Instantiate(fieldItemPrefab, new Vector3(251f, 21f, 70f), Quaternion.identity);
        //go3.GetComponent<DropItem>().SetItem(itemDB[2]);
        //GameObject go4 = Instantiate(fieldItemPrefab, new Vector3(251f, 21f, 76f), Quaternion.identity);
        //go4.GetComponent<DropItem>().SetItem(itemDB[3]);
        //GameObject go5 = Instantiate(fieldItemPrefab, new Vector3(245f, 21f, 76f), Quaternion.identity);
        //go5.GetComponent<DropItem>().SetItem(itemDB[4]);
        //GameObject go6 = Instantiate(fieldItemPrefab, new Vector3(245f, 21f, 70f), Quaternion.identity);
        //go6.GetComponent<DropItem>().SetItem(itemDB[5]);
        //GameObject go7 = Instantiate(fieldItemPrefab, new Vector3(245f, 25f, 70f), Quaternion.identity);
        //go7.GetComponent<DropItem>().SetItem(itemDB[6]);
    }
}
