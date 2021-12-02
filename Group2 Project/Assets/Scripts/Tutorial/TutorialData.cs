using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialData : MonoBehaviour
{
    public static TutorialData instance;

    public bool[] PanelFisrtLoad;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }

    
}
