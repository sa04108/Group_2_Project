using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public bool isAlwaysShowCursor;

    GameObject optionPanel;
    bool isOptionOn;

    // Start is called before the first frame update
    void Start()
    {
        isOptionOn = false;

        if (instance)
            Destroy(this);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);

        optionPanel = transform.Find("Option Panel").gameObject;
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
        if (!isAlwaysShowCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        optionPanel.SetActive(false);
    }

    public void SetVolume(float vol)
    {
        AudioSource[] audioSource = FindObjectsOfType<AudioSource>();
        foreach (var audio in audioSource)
        {
            audio.volume = vol / 2; // max 0.5
        }
    }
}
