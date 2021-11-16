using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] bool isDie = false;


    [Header("Monster Stats")]
    public int HP = 15;
    bool isAlive = true;



    //Animator animator;
    Animator ani;
    Rigidbody rb;
    [SerializeField]
    private GameObject ItemDrop;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {

        //»ç¸Á½Ã
        if (HP <= 0)
        {
            if (isAlive == true)
            {
                Debug.Log("Open");
                //animator.SetTrigger("Dead");
                
                ani.SetTrigger("IsOpen");
               
                isAlive = false;
                StartCoroutine(Open());
            }
        }

    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(2);
        Instantiate(ItemDrop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider coll)
    {

        if (coll.tag == "basicWeapon")
        {

            if (GameObject.Find("Player").GetComponent<CharacterAnimator>().isAttack == true)
            {
                HP = HP - (coll.gameObject.GetComponent<WeaponHitBox>().AttackPower);
                GameObject.Find("Player").GetComponent<CharacterAnimator>().isAttack = false;

            }
        }

    }

    }
