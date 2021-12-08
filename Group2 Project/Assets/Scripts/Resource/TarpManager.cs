using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TarpManager : MonoBehaviour
{
    public bool isRader = false;
    private Inventory inventory;

    private void Awake()
    {
        inventory = Inventory.instance;
        try
        {
            if (inventory.CheckItem("∑π¿Ã¥ı"))
            {
                isRader = true;
            }
            else
            {
                return;
            }
        }
        catch (NullReferenceException) { };
    }
}
