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
    public Transform meteor;
    public Transform meteor1;
    public Transform meteorPos;
    public bool isChase;
    [Header("rotationSpeed")]//플레이어쪽으로 돌리는 속도
    [SerializeField] float speed;



    
    


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
        MeteorDrop();
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
    public void MeteorDrop()
    {
        Invoke("MeteorInstantiate", 0.5f);
        Invoke("MeteorInstantiate", 0.55f);
        Invoke("MeteorInstantiate", 0.8f);
        Invoke("MeteorInstantiate", 0.85f);
        Invoke("MeteorInstantiate", 1.1f);
        Invoke("MeteorInstantiate", 1.2f);
        Invoke("MeteorInstantiate", 1.23f);
        Invoke("MeteorInstantiate", 1.5f);
        Invoke("MeteorInstantiate", 1.54f);
        Invoke("MeteorInstantiate", 1.7f);
        Invoke("MeteorInstantiate", 1.9f);
        Invoke("MeteorInstantiate", 2.0f);
        Invoke("MeteorInstantiate", 2.1f);
        Invoke("MeteorInstantiate", 2.2f);
        Invoke("MeteorInstantiate", 2.3f);
        Invoke("MeteorInstantiate", 2.35f);
        Invoke("ChasePlayer", 2.2f);
    }
    public void MeteorInstantiate()
    {
        isChase = false;
        float randomFloat = Random.Range(0.0f, 4.0f);
        
        if (randomFloat >= 2.0f)
        {

            Transform meteorIns = (Transform)Instantiate(meteor, meteorPos.position, transform.rotation);
        }
        else
        {

            Transform meteorIns = (Transform)Instantiate(meteor1, meteorPos.position, transform.rotation);
        }
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
