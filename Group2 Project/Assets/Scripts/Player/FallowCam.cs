using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowCam : MonoBehaviour
{
	public float distance = 5.0f;
	public float horizontalAngle = 0.0f;
	public float rotAngle = 180.0f; // ȭ�� ��������ŭ Ŀ���� �̵������� �� �� �� ȸ���ϴ°�.
	public float verticalAngle = 10.0f;
	public Transform lookTarget;
	public Vector3 offset = Vector3.zero;

	InputManager inputManager;
	void Start()
	{
		inputManager = FindObjectOfType<InputManager>();
	}

	// Update is called once per frame
	void LateUpdate()
	{
		// �巡�� �Է����� ī�޶� ȸ������ �����Ѵ�.
		if (inputManager.Moved())
		{
			float anglePerPixel = rotAngle / (float)Screen.width;
			Vector2 delta = inputManager.GetDeltaPosition();
			horizontalAngle += delta.x * anglePerPixel;
			horizontalAngle = Mathf.Repeat(horizontalAngle, 360.0f);
			verticalAngle -= delta.y * anglePerPixel;
			verticalAngle = Mathf.Clamp(verticalAngle, -60.0f, 60.0f);
		}

		// ī�޶��� ��ġ�� ȸ������ �����Ѵ�.
		if (lookTarget != null)
		{
			Vector3 lookPosition = lookTarget.position + offset;
			// �ֽ� ��󿡼� ��� ��ġ�� ���Ѵ�.
			Vector3 relativePos = Quaternion.Euler(verticalAngle, horizontalAngle, 0) * new Vector3(0, 0, -distance);

			// �ֽ� ����� ��ġ�� �������� ���� ��ġ�� �̵���Ų��.
			transform.position = lookPosition + relativePos;

			// �ֽ� ����� �ֽ��ϰ� �Ѵ�.
			transform.LookAt(lookPosition);

			// ��ֹ��� ���Ѵ�.
			RaycastHit hitInfo;
			if (Physics.Linecast(lookPosition, transform.position, out hitInfo, 1 << LayerMask.NameToLayer("Ground")))
				transform.position = hitInfo.point;
		}
	}
}
