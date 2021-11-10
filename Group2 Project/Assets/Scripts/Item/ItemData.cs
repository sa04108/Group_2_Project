using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static ItemData instance;
    private void Awake() {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();

    public GameObject fieldItemPrefab;

    public Vector3[] pos;

    private void Start() {
         GameObject go = Instantiate(fieldItemPrefab, new Vector3 (61.01f, 5f,39.04f), Quaternion.identity);
         go.GetComponent<DropItem>().SetItem(itemDB[6]);
        GameObject go2 = Instantiate(fieldItemPrefab, new Vector3(61.01f, 10f, 39.04f), Quaternion.identity);
        go2.GetComponent<DropItem>().SetItem(itemDB[7]);
        GameObject go3 = Instantiate(fieldItemPrefab, new Vector3(61.01f, 15f, 39.04f), Quaternion.identity);
        go3.GetComponent<DropItem>().SetItem(itemDB[8]);
        GameObject go4 = Instantiate(fieldItemPrefab, new Vector3(61.01f, 20f, 39.04f), Quaternion.identity);
        go4.GetComponent<DropItem>().SetItem(itemDB[9]);
    }
}
