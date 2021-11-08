using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCameraMove : MonoBehaviour
{
    float deltaAngle;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        deltaAngle = Time.deltaTime;

        StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, deltaAngle * rotationSpeed);
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);

            rotationSpeed *= -1;
        }
    }
}
