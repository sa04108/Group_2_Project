using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class ItemCreate : ScriptableObject
{
    public GameObject itemPrefab;
    public ITEM_TYPE itemType;
    public string itemName;
    public Sprite itemImage;
}
