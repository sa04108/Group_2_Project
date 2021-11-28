using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Rock : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 0.1f);
    }
}
