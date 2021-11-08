using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ITEM_TYPE {
    EQUIPMENT,
    RESOURCES,
    CONSUMABLES,
}

[System.Serializable]
public class Item 
{
    public ITEM_TYPE itemType;
    public string itemName;
    public Sprite itemImage;
    public Mesh itemModel;
    public Material itemMaterial;
}
  

