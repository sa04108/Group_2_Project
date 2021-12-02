using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private TutorialData tutorial;
    public int Wallnum;
    private void Awake()
    {
        tutorial = TutorialData.instance;

        if(tutorial.Wallcollaps[Wallnum])
        {
            Destroy(this.gameObject);
        }
    }
}
