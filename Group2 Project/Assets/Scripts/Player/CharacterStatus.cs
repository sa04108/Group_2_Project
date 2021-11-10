using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [Header("Player's Stats")]
    public int HP=100;
    public int AttackPower=5;
    
    
    
    public Vector3 Ppos;

    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}