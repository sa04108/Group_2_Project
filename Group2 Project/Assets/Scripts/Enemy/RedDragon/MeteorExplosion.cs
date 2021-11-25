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
        //흩뿌려주는 용
        dropDirX = Random.Range(-0.013f, 0.013f);
        dropDirZ = Random.Range(-0.013f, 0.013f);
        // 용 앞쪽으로 이동시켜주는 용
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
