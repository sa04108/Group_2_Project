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
        //    obj = GameObject.Find("MBW");
        //this.gameObject.SetActive(false);
        wall.gameObject.SetActive(false);

    }
    // Update is called once per frame

}
