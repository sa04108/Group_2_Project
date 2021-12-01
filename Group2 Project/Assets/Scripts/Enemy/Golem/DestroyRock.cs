using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up* 0.03f);
        Destroy(gameObject, 1.5f);
    }
}
