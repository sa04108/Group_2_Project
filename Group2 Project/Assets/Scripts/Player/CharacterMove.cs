using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]

    public float gravity = 100f;
    public float speed = 5.0f;      //걷기속도
    public float RotSpeed = 1.0f;   //회전속도
    public float runSpeed = 3.0f;   //달리기 추가속도


  
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
            //좌우로 방향을 바꾼다.
            float x = Input.GetAxisRaw("Horizontal");
            transform.Rotate(Vector3.up * x * RotSpeed);
            
            //앞으로 이동한다.
            moveDirection = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));

        }

        Run(); //달리기 확인

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(Time.deltaTime * transform.TransformDirection(moveDirection) * speed);

    }

    void Run()
    {
        //달릴 때 속도를 더한다.
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += runSpeed;
        }
        //달리지 않을 때 속도를 원래대로 돌린다.
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= runSpeed;
        }

    }


}
