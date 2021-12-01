using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPosMove : MonoBehaviour
{
    public bool MeteorPosMoveOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (MeteorPosMoveOn == true)
        {
            this.transform.Translate(new Vector3(0, 0, 30f) * Time.deltaTime);
        }
    }
    
    public void PositionReset()
    {
        Invoke("PositionResetDelay", 0.5f);
    }
    public void PositionResetDelay()
    {
        transform.localPosition = new Vector3(0, 40, -20);
    }
}
