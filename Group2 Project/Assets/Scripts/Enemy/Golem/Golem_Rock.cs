using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Rock : MonoBehaviour
{
    public GameObject DestRock;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 0.1f);
        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.name == "Terrain")
        {
            Instantiate(DestRock, gameObject.transform.position, gameObject.transform.rotation);
        }
        else
            return;
    }
}
