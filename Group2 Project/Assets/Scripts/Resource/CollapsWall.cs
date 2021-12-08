using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsWall : MonoBehaviour
{
    [SerializeField]
    private float DestroyTime;

    [SerializeField]
    private Collider col;
    [SerializeField]
    private GameObject Wall;
    [SerializeField]
    private GameObject Wall_debris;

    private TutorialData tutorial;

    private void Start()
    {
        tutorial = TutorialData.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bomb")
        {
            Destruction();
        }
    }
    private void Destruction()
    {
        col.enabled = false;

        Wall.SetActive(false);

        Wall_debris.SetActive(true);
        Destroy(Wall_debris, DestroyTime);

        tutorial.Wallcollaps[this.gameObject.GetComponent<Wall>().Wallnum] = true;
    }
}
