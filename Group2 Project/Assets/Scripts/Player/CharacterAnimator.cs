using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    Animator animator;
    CharacterMove characterMove;
    PlayerStatus playerStatus;
    AudioSource audioSource;

    public AudioClip[] audioClips;
    public bool isAttack;
    bool isWalk;

    float playerHP;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterMove = GetComponent<CharacterMove>();
        playerStatus = GetComponent<PlayerStatus>();
        audioSource = GetComponent<AudioSource>();
        
        isAttack = false;
        isWalk = false;
        playerHP = playerStatus.PlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        
        Walk();
        Run();
        Attack();
        GetHit();
        Dead();
        
    }

    void PlaySound(int clipIdx)
    {
        audioSource.clip = audioClips[clipIdx];
        audioSource.Play();
    }

    void GetHit()
    {
        // Debug.Log(playerHP);
        // Debug.Log(playerStatus.PlayerHP);
        //맞으면 실행
        if (playerHP != playerStatus.PlayerHP)
        {
            animator.SetBool("GetHit", true);
            PlaySound(0);
        }
        else
            animator.SetBool("GetHit", false);

        playerHP = playerStatus.PlayerHP;

    }
    void Walk()
    {
        //WASD중 하나라도 선택되었다면 걷는다.

        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Walk", true);
            if (!isWalk)
            {
                isWalk = true;
                PlaySound(1);
                Invoke("ResetWalk", 1.0f);
            }
        }
        else 
        {
            animator.SetBool("Walk", false);
        }

    }
    void ResetWalk()
    {
        isWalk = false;
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

    //void Attack()
    //{
    //    //공격모션
    //    if (Input.GetButtonUp("Fire1"))
    //    {
    //        animator.SetBool("Attack", true);
    //        isAttack = true;
    //    }
    //    else
    //        animator.SetBool("Attack", false);
    //}

                //  11/24 *수요일 회의 전 김연완 제안, isAttack을 이용하여 무기들 Collider 해제
    void Attack()
    {
        //공격모션
        if (Input.GetButtonUp("Fire1"))
        {
            if (!isAttack)
            {
                StartCoroutine("Swing");
            }
        }
    }

    IEnumerator Swing()
    {
        animator.SetBool("Attack", true);
        isAttack = true;

        yield return new WaitForSeconds(0.35f);

        animator.SetBool("Attack", false);
        isAttack = false;

    }
    void Dead()
    {
        if(playerStatus.GameOver())
        {
            animator.SetBool("Dead", true);
            PlaySound(2);
        }
    }
}
