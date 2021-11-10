using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowCam : MonoBehaviour
{

	public GameObject Cam;
	public Vector3 offset = Vector3.zero;

	public float rotSpeed = 8;
	public float x;


	void Start()
	{
		//Debug.Log(Cam.transform.eulerAngles);
	}

	// Update is called once per frame
	void LateUpdate()
	{

		//Debug.Log(Cam.transform.localRotation) ;

		x = Input.GetAxis("Mouse Y");

		if (Cam.transform.localRotation.x > 0.3&&x<0)
			x = 0;

		if (Cam.transform.localRotation.x < -0.3&&x>0)
			x = 0;

		transform.Rotate(Vector3.left * x * rotSpeed);
		x = Input.GetAxis("Mouse Y");


	}
}
