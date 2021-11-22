using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShooter : MonoBehaviour
{
    public GameObject bomb;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Destroy(Instantiate(bomb, transform.parent.position, Quaternion.LookRotation(Camera.main.transform.forward)), 3.0f);
        }
    }
}
