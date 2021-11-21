using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject arrow;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Destroy(Instantiate(arrow, transform.parent.position, Quaternion.LookRotation(Camera.main.transform.forward)), 1.0f);
        }
    }
}
