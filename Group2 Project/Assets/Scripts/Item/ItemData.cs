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
         go.GetComponent<DropItem>().SetItem(itemDB[Random.Range(0, 3)]);
    }
}
