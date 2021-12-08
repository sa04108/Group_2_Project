using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TutorialFirstLoad : MonoBehaviour
{
    private TutorialData tutorial;

    public int SquenceNum;

    private void Awake()
    {
        tutorial = TutorialData.instance;
        try
        {
            if (tutorial.PanelFisrtLoad[SquenceNum])
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
