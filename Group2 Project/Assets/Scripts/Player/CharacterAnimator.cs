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
        //������ ����
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
        //WASD�� �ϳ��� ���õǾ��ٸ� �ȴ´�.

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
        //�ȴ� �� leftshift�� ������ �޸���.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Run", true);
        }
        else
            animator.SetBool("Run", false);
    }

    //void Attack()
    //{
    //    //���ݸ��
    //    if (Input.GetButtonUp("Fire1"))
    //    {
    //        animator.SetBool("Attack", true);
    //        isAttack = true;
    //    }
    //    else
    //        animator.SetBool("Attack", false);
    //}

                //  11/24 *������ ȸ�� �� �迬�� ����, isAttack�� �̿��Ͽ� ����� Collider ����
    void Attack()
    {
        //���ݸ��
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
