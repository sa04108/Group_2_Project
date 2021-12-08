using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public bool isAttack = false;
    public int AttackPower = 2;
    GameObject HitThePlayer;
    Inventory inven;

    // Start is called before the first frame update
    void Start()
    {
        inven = Inventory.instance;
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
                Equipment shield = inven.SearchEquipment(EQUIP_TYPE.SHIELD);

                PlayerStatus playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
                
                if (shield == null) {
                    playerStatus.PlayerHP -= AttackPower;
                }
                else {
                    int blockedDamage = AttackPower - shield.damage;
                   
                    if (blockedDamage < 0) blockedDamage = 0;
                    playerStatus.PlayerHP -= blockedDamage;
                }
                
            }

        }

    }

    public void Attacking()
    {
        isAttack = true;
    }
    public void StopAttacking()
    {
        isAttack = false;
    }

}
