using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Leave()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; //커서 위치 고정, 보이지 않게 한다.
        SceneManager.LoadScene("Scene");
    }
}
