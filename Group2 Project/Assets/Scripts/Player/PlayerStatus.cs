using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Player's Stats")]
    public float PlayerHP = 100f;
    public int AttackPower = 5;

    public static Vector3 lastPlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        if (lastPlayerPos != Vector3.zero)
            transform.position = lastPlayerPos + Vector3.back * 5;
    }

    // Update is called once per frame
    void Update()
    {
        lastPlayerPos = transform.position;
    }

    public bool GameOver()
    {
        if (PlayerHP <= 0)
            return true;
        else
            return false;
    }
    

}
