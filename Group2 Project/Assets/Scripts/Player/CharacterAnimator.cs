using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    Animator animator;
    CharacterMove characterMove;
    InputManager inputManager;
    public bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterMove = GetComponent<CharacterMove>();
        inputManager = FindObjectOfType<InputManager>();
        isAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Run();
        Attack();

    }

    void Walk()
    {
        //WASD�� �ϳ��� ���õǾ��ٸ� �ȴ´�.

        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Walk", true);
        }
        else 
        {
            animator.SetBool("Walk", false);
        }
    }
    void Run()
    {
        //�ȴ� �� leftshift�� ������ �޸���.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Run", true);
        }
        else
            animator.SetBool("Run", false);
    }

    void Attack()
    {
        //���ݸ��
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("Attack", true);
            isAttack = true;
        }
        else
            animator.SetBool("Attack", false);
    }
}
