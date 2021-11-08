using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropItem : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item) {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        item.itemModel = _item.itemModel;
        item.itemMaterial = _item.itemMaterial;
        item.itemCount = _item.itemCount;
       // gameObject.GetComponent<MeshRenderer>().
        gameObject.GetComponent<MeshRenderer>().material=item.itemMaterial;

        //image.sprite = item.itemImage;
    }

    public Item GetItem() {
        return item;
    }

    public void DestroyItem() {
        Destroy(gameObject);
    }
}
