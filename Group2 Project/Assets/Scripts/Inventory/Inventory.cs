using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    [SerializeField] public int slots;

    public void GetItem(Item item) {
        if(items.Count < slots) {
            items.Add(item);
        }
    }

    public bool IsFull() {
        if(items.Count >= slots) {
            return true;
        }
        return false;
    }
}
