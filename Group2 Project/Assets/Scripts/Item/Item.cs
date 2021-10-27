using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEM_TYPE {
    EQUIPMENT,
    RESOURCES,
    CONSUMABLES,
}

public class Item : MonoBehaviour
{
    public ITEM_TYPE itemType;
    public string itemName;
    public Sprite itemImage;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Inventory inven = GameObject.FindObjectOfType<Inventory>();

            if (!inven.IsFull()) {
                inven.GetItem(this);
            }
            
        }
    }

    public void DestroyItem() {
        Destroy(gameObject);
    }
}
