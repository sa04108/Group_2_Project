using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        if(other.CompareTag("fieldResource")) {
            Debug.Log("target: resource");

            //other.gameObject.GetComponent<Rock>().Mining(gameObject.GetComponent<>);
        }
    }
}
