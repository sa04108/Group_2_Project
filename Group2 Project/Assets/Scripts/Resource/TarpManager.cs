using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarpManager : MonoBehaviour
{
    public bool isRader = false;
    private Inventory inventory;

    private void Awake()
    {
        inventory = Inventory.instance;
        if(inventory.CheckItem("∑π¿Ã¥ı"))
        {
            isRader = true;
        }
    }
}
