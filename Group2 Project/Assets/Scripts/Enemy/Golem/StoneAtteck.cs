using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneAtteck : MonoBehaviour
{
    public GameObject Rock;
    public GameObject Hand;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("Attack1", true);
            AttackRock();
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            animator.SetBool("Attack1", false);
        }
    }

    void AttackRock()
    {
        Rock.transform.position = Hand.transform.position;
        Rock.SetActive(true);
    }
}
