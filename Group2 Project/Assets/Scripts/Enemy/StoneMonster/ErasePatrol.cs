using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErasePatrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EraseThis()
    {
        Destroy(this.gameObject, 1.7f);
        Debug.Log("몬스터 삭제");
    }
}
