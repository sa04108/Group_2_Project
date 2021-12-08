using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wall : MonoBehaviour
{
    private TutorialData tutorial;
    public int Wallnum;
    private void Awake()
    {
        tutorial = TutorialData.instance;
        try
        {
            if (tutorial.Wallcollaps[Wallnum])
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                return;
            }
        }
        catch (NullReferenceException) { };
    }
}
