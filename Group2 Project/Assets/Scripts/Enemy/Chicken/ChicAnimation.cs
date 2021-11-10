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
        Walking();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Walking()
    {
        animator.SetInteger("Walk", 1);
        status = 1;
        Debug.Log("walk");
    }
    public void WalkingStop()
    {
        animator.SetInteger("Walk", 0);
        status = 2;
        Debug.Log("no walk");
    }
    public void Attack()
    {
        animator.SetTrigger("Attack");
        status = 3;
        Debug.Log("at");
    }
    public void idle()
    {

    }

    public void jump()
    {
        status = 4;
        animator.SetTrigger("jump");
        Debug.Log("jump");

    }

    public void Dead()
    {
        status = 5;
        animator.SetTrigger("Dead");
        Debug.Log("Dead");
    }


}