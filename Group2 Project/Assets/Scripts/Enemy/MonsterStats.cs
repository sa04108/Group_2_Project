using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    [Header("Monster Stats")]
    public int HP = 15;
    public int AttackPower = 2;
    public bool isAttack = false;
    public GameObject AttackHead;
    public GameObject ChicAni;
    public bool isAlive = true;
}
