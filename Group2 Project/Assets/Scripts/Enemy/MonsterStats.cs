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
    //public GameObject ChicAni; 치킨만 애니메이터가 자식에 붙어있어서 추가한거였습니다.
    public bool isAlive = true;
}
