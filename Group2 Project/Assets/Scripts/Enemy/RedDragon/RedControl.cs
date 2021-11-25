using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedControl : MonoBehaviour
{
    Animator animator;
    public Vector3 pos;
    public Transform target;
    public int life;
    

    [Header("rotationSpeed")]//�÷��̾������� ������ �ӵ�
    [SerializeField] float speed;
    //�÷��̾ �ٶ󺸴°� ����
    public bool isChase;






    //bool isDie = false;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = 0.8f;
        life = 10;
        isChase = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        //Ư�� �ִϸ��̼ǵ����� �÷��̾������� ȸ�� ����. ���߿� ���� �� ��
        if( isChase == true)
        {
            pos = transform.position;
            var rotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);

        }
        /*
        if(life <= 0)
        {
            
            Invoke("GameEnd", 15f);
            Player player = GameObject.Find("PlayerFps").GetComponent<Player>();
            

            if(isDie == false)
            {
                animator.SetTrigger("Die");
                isDie = true;

            }
        }*/




    }

    public void GameEnd()
    {
        /*
        SceneManager.LoadScene("GameOver1");
        Cursor.lockState = CursorLockMode.None;
        //Ŀ�� �����
        Cursor.visible = true;
        */
        
    }
    
    public void ChasePlayer()
    {
        isChase = true;
    }
    public void NoChasePlayer()
    {
        isChase = false;
    }
}
