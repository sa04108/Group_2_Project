using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropItemUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 velocity = Random.insideUnitSphere * 1.0f + Vector3.up * 5.0f;
        GetComponent<Rigidbody>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
