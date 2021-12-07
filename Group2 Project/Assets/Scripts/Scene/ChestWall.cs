using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestWall : MonoBehaviour
{

    public GameObject wall;
    public float FadeTime = 0f;
    Color Col;
    Material mat;

    // Start is called before the first frame update

    private void Start()
    {
        //Col = wall.GetComponent<MeshRenderer>().material.color;
        //mat = wall.GetComponent<MeshRenderer>().material;
        Col = wall.gameObject.GetComponent<MeshRenderer>().material.color;
        //mat = wall.gameObject.GetComponent<MeshRenderer>().material;


    }
    void update()
    {

    }

    public void activeF()
    {
       float time = 0f;

        while (Col.a > 0f)
        {
            Debug.Log("check");

            time += Time.deltaTime / FadeTime;
            Col.a = Mathf.Lerp(1, 0, time);

            wall.gameObject.GetComponent<MeshRenderer>().material.color = Col;
        }

        if (Col.a == 0)
        {
            Debug.Log("sa_wall");
            wall.gameObject.SetActive(false);
        }
        //StartCoroutine(fade());

    }

    public void setActiveF()
    {
        wall.gameObject.SetActive(false);
    }

    //IEnumerator fade()
    //{
    //    while (mat.color.a > 0)
    //    {
    //        Color Col = mat.color;
    //        Col.a -= (Time.deltaTime);
    //        mat.color = Col;
    //        this.GetComponent<MeshRenderer>().material = mat;
    //    }
    //    yield return new WaitForSeconds(2);

    //    this.gameObject.SetActive(false);
    //}

}
