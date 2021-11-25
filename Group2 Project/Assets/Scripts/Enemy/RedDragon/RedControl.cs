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
    

    [Header("rotationSpeed")]//플레이어쪽으로 돌리는 속도
    [SerializeField] float speed;
    //플레이어를 바라보는가 유무
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

        //특정 애니메이션동안은 플레이어쪽으로 회전 안함. 나중에 조건 줄 것
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
        //커서 숨기기
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
