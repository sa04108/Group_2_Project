using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]

    public float gravity = 100f;
    public float speed = 5.0f;      //�ȱ�ӵ�
    public float RotSpeed = 1.0f;   //ȸ���ӵ�
    public float runSpeed = 3.0f;   //�޸��� �߰��ӵ�


  
    private Vector3 moveDirection;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            //�¿�� ������ �ٲ۴�.
            float x = Input.GetAxisRaw("Horizontal");
            transform.Rotate(Vector3.up * x * RotSpeed);
            
            //������ �̵��Ѵ�.
            moveDirection = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));

        }

        Run(); //�޸��� Ȯ��

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(Time.deltaTime * transform.TransformDirection(moveDirection) * speed);

    }

    void Run()
    {
        //�޸� �� �ӵ��� ���Ѵ�.
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += runSpeed;
        }
        //�޸��� ���� �� �ӵ��� ������� ������.
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= runSpeed;
        }

    }


}
