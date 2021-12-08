using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public GameObject optionPanel;

    bool isOptionOn;

    // Start is called before the first frame update
    void Start()
    {
        isOptionOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (isOptionOn)
                HideOptionPanel();
            else
                ShowOptionPanel();
    }

    public void ShowOptionPanel()
    {
        isOptionOn = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        optionPanel.SetActive(true);
    }

    public void HideOptionPanel()
    {
        isOptionOn = false;
        if (SceneManager.GetActiveScene().name == "Scene" || SceneManager.GetActiveScene().name == "Boss")
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        optionPanel.SetActive(false);
    }
}
