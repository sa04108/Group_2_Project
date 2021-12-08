using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChestWall : MonoBehaviour
{
    public GameObject wall;
    private MonsterStats monsterStats;


    // Start is called before the first frame update
    private void Start()
    {
    }
    private void OnDestroy()
    {
        //wall.gameObject.SetActive(false);
        //wall.GetComponent<ChestWall>().activeF();

    }

    private void Update()
    {
        monsterStats = gameObject.GetComponent<MonsterStats>();
        if (monsterStats.HP <= 0)
        {
            wall.GetComponent<ChestWall>().activeF();
        }
    }

}
