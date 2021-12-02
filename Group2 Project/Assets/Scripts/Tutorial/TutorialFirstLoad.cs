using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFirstLoad : MonoBehaviour
{
    private TutorialData tutorial;

    public int SquenceNum;

    private void Awake()
    {
        tutorial = TutorialData.instance;

        if(tutorial.PanelFisrtLoad[SquenceNum])
        {
            Destroy(this.gameObject);
        }
    }
}
