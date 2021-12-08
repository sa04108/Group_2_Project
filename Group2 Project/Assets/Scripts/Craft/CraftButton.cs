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
        Cursor.lockState = CursorLockMode.Locked; //Ŀ�� ��ġ ����, ������ �ʰ� �Ѵ�.
        SceneManager.LoadScene("Scene");
    }
}
