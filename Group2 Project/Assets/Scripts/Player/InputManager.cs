using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
	Vector2 slideStartPosition;
	Vector2 prevPosition;
	Vector2 delta = Vector2.zero;
	bool moved = false;

	void Update()
	{
		// �����̵� ���� ����.
		if (Input.GetButtonDown("Fire1"))
			slideStartPosition = GetCursorPosition();

		// ȭ�� �ʺ��� 10% �̻� Ŀ���� �̵���Ű�� �����̵� �������� �Ǵ��Ѵ�.
		if (Input.GetButton("Fire1"))
		{
			if (Vector2.Distance(slideStartPosition, GetCursorPosition()) >= (Screen.width * 0.1f))
				moved = true;
		}

		// �����̵尡 �����°�.
		if (!Input.GetButtonUp("Fire1") && !Input.GetButton("Fire1"))
			// �����̵�� ������.
			moved = false;

		// �̵����� ���Ѵ�.
		if (moved)
			delta = GetCursorPosition() - prevPosition;
		else
			delta = Vector2.zero;

		// Ŀ�� ��ġ�� �����Ѵ�.
		prevPosition = GetCursorPosition();
	}

	// Ŭ���Ǿ��°�.
	public bool Clicked()
	{
		if (!moved && Input.GetButtonUp("Fire1"))
			return true;
		else
			return false;
	}

	// �����̵��� �� Ŀ�� �̵���.
	public Vector2 GetDeltaPosition()
	{
		return delta;
	}

	// �����̵� ���ΰ�.
	public bool Moved()
	{
		return moved;
	}

	public Vector2 GetCursorPosition()
	{
		return Input.mousePosition;
	}
}
