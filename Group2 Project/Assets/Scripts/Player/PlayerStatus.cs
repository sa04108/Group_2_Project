using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    [Header("Player's Stats")]
    public float PlayerHP = 100f;
    public int AttackPower = 5;
    GameObject obj;
    bool isBurning;

    Esder esder;
    // Start is called before the first frame update
    void Start()
    {
        isBurning = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool GameOver()
    {
        if (PlayerHP <= 0)
        {
            Invoke("backToTitle", 2f);
            return true;
        }
        else
            return false;
    }

    public void backToTitle()
    {
        SceneManager.LoadScene("Title");
    }


    

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "dropItem") 
        {
            GameObject soundPrefab = Instantiate(Resources.Load("SoundSourcePrefab", typeof(GameObject)) as GameObject);

            soundPrefab.GetComponent<CharacterLootingSound>().InitPrefab(other.tag);

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
        if (other.tag == "Portion")
        {
            GameObject soundPrefab = Instantiate(Resources.Load("SoundSourcePrefab", typeof(GameObject)) as GameObject);

            soundPrefab.GetComponent<CharacterLootingSound>().InitPrefab(other.tag);

            PlayerHP = PlayerHP + 100;
            if (PlayerHP >= 100)
            {
                PlayerHP = 100;
            }
            Destroy(other.gameObject, 0.01f);
        }
        //Esder 태그의 아이탬 습득시 데미지 15

        if (other.tag == "Esder")
        {
            esder = FindObjectOfType<Esder>();
            esder.esderP = 25;
            
            Destroy(other.gameObject, 0.01f);
        }

    }
    
    public void Burning(float x)
    {
        if(isBurning == false)
        {
            isBurning = true;
            InvokeRepeating("BurningDamage", 0.5f, 0.5f);
            Invoke("BurningEnd", x);

        }
    }
    void BurningEnd()
    {
        CancelInvoke("BurningDamage");
        isBurning = false;
    }
    void BurningDamage()
    {
        PlayerHP = PlayerHP - 5;
    }

    private void OnParticleCollision(GameObject other)
    {
        Burning(2);
    }
}
