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

    public List<Equipment> equipDB = new List<Equipment>();

    public GameObject fieldItemPrefab;

    public Vector3[] pos;

    private void Start() {

         GameObject go = Instantiate(fieldItemPrefab, new Vector3 (266f, 21f, 70f), Quaternion.identity);
         go.GetComponent<DropItem>().SetItem(itemDB[0]);
        GameObject go2 = Instantiate(fieldItemPrefab, new Vector3(263f, 21f, 76f), Quaternion.identity);
        go2.GetComponent<DropItem>().SetItem(itemDB[1]);
        GameObject go3 = Instantiate(fieldItemPrefab, new Vector3(251f, 21f, 70f), Quaternion.identity);
        go3.GetComponent<DropItem>().SetItem(itemDB[2]);
        GameObject go4 = Instantiate(fieldItemPrefab, new Vector3(251f, 21f, 76f), Quaternion.identity);
        go4.GetComponent<DropItem>().SetItem(itemDB[3]);
        GameObject go5 = Instantiate(fieldItemPrefab, new Vector3(245f, 21f, 76f), Quaternion.identity);
        go5.GetComponent<DropItem>().SetItem(itemDB[4]);
        GameObject go6 = Instantiate(fieldItemPrefab, new Vector3(245f, 21f, 70f), Quaternion.identity);
        go6.GetComponent<DropItem>().SetItem(itemDB[5]);
    }
}
