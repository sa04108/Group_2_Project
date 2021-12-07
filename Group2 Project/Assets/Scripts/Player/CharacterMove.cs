using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour
{
    public static Vector3 lastPos = Vector3.zero;

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
        characterController.enabled = false;

        if (lastPos != Vector3.zero && SceneManager.GetActiveScene().name == "Scene")
            transform.position = lastPos;

        characterController.enabled = true;
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            //좌우로 방향을 바꾼다.
            float x = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up * x * RotSpeed);
            
            //이동한다.
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tent"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            AudioManager.instance.SetAlwaysShowCursor(true);
            lastPos = other.transform.position + new Vector3(0f, 10f, -5f);
            SceneManager.LoadScene("Tent");
        }
    }
}
