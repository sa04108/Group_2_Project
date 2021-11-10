using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftButton : MonoBehaviour
{
    [SerializeField]
    private GameObject CraftManual;
    private bool OnCraftManual;

    private void Start()
    {
        OnCraftManual = false;
    }
    public void ClickButton()
    {
        if (!OnCraftManual)
        {
            CraftManual.SetActive(true);
            OnCraftManual = true;
        }

        else
        {
            CraftManual.SetActive(false);
            OnCraftManual = false;
        }
    }
}
