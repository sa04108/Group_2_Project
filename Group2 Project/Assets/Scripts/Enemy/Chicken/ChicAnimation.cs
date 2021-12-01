using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicAnimation : MonoBehaviour
{


    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void Walking()
    {
        animator.SetInteger("Walk", 1);

    }
    public void WalkingStop()
    {
        animator.SetInteger("Walk", 0);

    }
    public void Attack()
    {
        animator.SetTrigger("Attack");

    }
    public void idle()
    {

    }

    public void jump()
    {
        animator.SetTrigger("jump");

    }

    public void Dead()
    {
        animator.SetTrigger("Dead");
    }

    public void ChicIsAttackTrue()
    {
        transform.Find("Body").gameObject.GetComponent<AttackArea>().isAttack = true;
    }
    public void ChicIsAttackfalse()
    {
        transform.Find("Body").gameObject.GetComponent<AttackArea>().isAttack = false;
    }
}