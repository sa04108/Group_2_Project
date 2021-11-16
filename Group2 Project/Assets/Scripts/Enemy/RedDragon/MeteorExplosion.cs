using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorExplosion : MonoBehaviour
{
    float dropDirX;
    float dropDirZ;
    public GameObject meteorEffect;
    float dropPlusZ;

    // Start is called before the first frame update
    void Start()
    {
        dropDirX = Random.Range(-0.010f, 0.010f);
        dropDirZ = Random.Range(-0.010f, 0.010f);
        dropPlusZ = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dropDirX, 0, dropDirZ+dropPlusZ);
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            Instantiate(meteorEffect, transform.position, transform.rotation);
            Destroy(gameObject, 0.1f);
        }
    }
}
