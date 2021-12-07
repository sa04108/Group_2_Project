using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChestWall : MonoBehaviour
{
    ChestWall chestWall;
    public GameObject wall;

    // Start is called before the first frame update
    private void Start()
    {
        //chestWall = GameObject.Find("MBW").GetComponent<ChestWall>();
    }
    private void OnDestroy()
    {
        //wall.gameObject.SetActive(false);
        wall.GetComponent<ChestWall>().activeF();

    }
    // Update is called once per frame

}
