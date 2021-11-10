using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public bool isAttack = false;
    public int AttackPower = 2;
    GameObject HitThePlayer;

    // Start is called before the first frame update
    void Start()
    {
        isAttack = false;
        AttackPower = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            if (isAttack == true)
            {
                PlayerStatus playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
                playerStatus.PlayerHP -= AttackPower;
            }

        }

    }
}
