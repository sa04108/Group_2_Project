using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicAnimation : MonoBehaviour
{
    public int status = 0;


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
        status = 1;
        animator.SetInteger("Walk", 1);
        
    }
    public void WalkingStop()
    {
        status = 2;
        animator.SetInteger("Walk", 0);
        
    }
    public void Attack()
    {
        status = 3;
        animator.SetTrigger("Attack");
        
    }
    public void idle()
    {

    }

    public void jump()
    {
        status = 4;
        animator.SetTrigger("jump");

    }

    public void Dead()
    {
        status = 5;
        animator.SetTrigger("Dead");
    }


}