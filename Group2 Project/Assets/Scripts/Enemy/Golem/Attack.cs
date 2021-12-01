using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    MonsterStats monsterStats;
    PlayerStatus playerStatus;


    // Start is called before the first frame update
    void Start()
    {
        monsterStats = GameObject.Find("HP_Golem").GetComponent<MonsterStats>();
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            if (monsterStats.isAttack == true)
            {
                playerStatus.PlayerHP -= monsterStats.AttackPower;
                monsterStats.isAttack = false;

            }
            else
                return;
        }
        else
            return;


    }

}
