using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Player's Stats")]
    public float PlayerHP = 100f;
    public int AttackPower = 5;
    GameObject obj;

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

    

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "dropItem") 
        {
            DropItem dropItems = other.GetComponent<DropItem>();

            if (Inventory.instance.AddItem(dropItems.GetItem())) 
            {
                dropItems.DestroyItem();
            }
        }

        if (other.tag == "ChickenLeg")
        {
            PlayerHP = PlayerHP + 30;
            if (PlayerHP >= 100)
            {
                PlayerHP = 100;
            }
            Destroy(other.gameObject, 0.01f);
        }
        //Esder 태그의 아이탬 습득시 데미지 15
        if (other.tag == "Esder")
        {
            obj = GameObject.Find("Sword");
            obj.GetComponent<WeaponHitBox>().AttackPower = 15;
            Destroy(other.gameObject, 0.01f);
        }

    }

}
