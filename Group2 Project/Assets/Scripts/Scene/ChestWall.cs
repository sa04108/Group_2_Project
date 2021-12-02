using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestWall : MonoBehaviour
{
    private Material mat;
    public GameObject golem;
    int hp;

    public bool isDestroy = false;
    // Start is called before the first frame update

    private void Start()
    {
        golem = GameObject.Find("HP_GOLEM");
        hp = golem.GetComponent<MonsterStats>().HP;
        mat = this.GetComponent<MeshRenderer>().material;
    }
    void update()
    {
        if (hp <= 0)
        {
            Debug.Log("startCo");
            while (mat.color.a > 0)
            {
                Color Col = mat.color;
                Col.a -= (Time.deltaTime);
                mat.color = Col;
                this.GetComponent<MeshRenderer>().material = mat;
            }
            Invoke("activeF", 1f);
            //StartCoroutine(fade());
        }
    }

    void activeF()
    {
        this.gameObject.SetActive(false);
    }

    //IEnumerator fade()
    //{
    //    while (mat.color.a > 0)
    //    {
    //        Color Col = mat.color;
    //        Col.a -= (Time.deltaTime);
    //        mat.color = Col;
    //        wall.GetComponent<MeshRenderer>().material = mat;
    //    }
    //    yield return new WaitForSeconds(2);

    //    wall.gameObject.SetActive(false);
    //}

}
