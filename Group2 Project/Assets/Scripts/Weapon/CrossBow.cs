using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject arrow;

    const float delay = 0.35f;
    bool isReady;

    private void Start()
    {
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1") && isReady)
            StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        Destroy(Instantiate(arrow, transform.parent.position, Quaternion.LookRotation(Camera.main.transform.forward)), 1.0f);
        isReady = false;

        yield return new WaitForSeconds(delay);
        isReady = true;
    }
}
