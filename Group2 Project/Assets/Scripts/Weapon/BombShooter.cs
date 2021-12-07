using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShooter : MonoBehaviour
{
    public GameObject bomb;

    const float delay = 2.0f;
    bool isReady;

    private void Start()
    {
        isReady = true;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1") && isReady)
            StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        Destroy(Instantiate(bomb, transform.parent.position, Quaternion.LookRotation(Camera.main.transform.forward)), 3.0f);
        isReady = false;

        yield return new WaitForSeconds(delay);
        isReady = true;
    }
}
