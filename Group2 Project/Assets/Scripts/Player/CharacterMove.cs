using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour
{
    public static Vector3 lastPos = Vector3.zero;

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
        characterController.enabled = false;

        if (lastPos != Vector3.zero && SceneManager.GetActiveScene().name == "Scene")
            transform.position = lastPos;

        characterController.enabled = true;
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            //�¿�� ������ �ٲ۴�.
            float x = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up * x * RotSpeed);
            
            //�̵��Ѵ�.
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
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
