using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]

    public float gravity = 100f;
    public float speed = 5.0f;
    public float RotSpeed = 3.0f;

    bool move = false;

  
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

            float x = Input.GetAxisRaw("Horizontal");

            transform.Rotate(Vector3.up * x * RotSpeed);

            moveDirection = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));

        }

        Run();

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(Time.deltaTime * transform.TransformDirection(moveDirection) * speed);

    }

    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += 3;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= 3;
        }

    }


}
