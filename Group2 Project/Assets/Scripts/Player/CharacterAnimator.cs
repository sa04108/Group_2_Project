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
        //WASD중 하나라도 선택되었다면 걷는다.

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
        //걷는 중 leftshift가 눌리면 달린다.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Run", true);
        }
        else
            animator.SetBool("Run", false);
    }

    void Attack()
    {
        //공격모션
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("Attack", true);
            isAttack = true;
        }
        else
            animator.SetBool("Attack", false);
    }
}
