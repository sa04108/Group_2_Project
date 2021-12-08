using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    MonsterStats monsterStats;
    PlayerStatus playerStatus;

    Inventory inven;

    // Start is called before the first frame update
    void Start()
    {
        inven = Inventory.instance;
        monsterStats = GameObject.Find("HP_Golem").GetComponent<MonsterStats>();
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            if (monsterStats.isAttack == true)
            {
                Equipment shield = inven.SearchEquipment(EQUIP_TYPE.SHIELD);

                if (shield == null) {
                    playerStatus.PlayerHP -= monsterStats.AttackPower;
                }
                else {
                    int blockedDamage = monsterStats.AttackPower - shield.damage;

                    if (blockedDamage < 0) blockedDamage = 0;
                    playerStatus.PlayerHP -= blockedDamage;
                }
              
                monsterStats.isAttack = false;

            }
            else
                return;
        }
        else
            return;


    }

}
