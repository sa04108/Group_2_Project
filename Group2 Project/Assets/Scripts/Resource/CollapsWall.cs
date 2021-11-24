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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bomb")
        {
            Destruction();
        }
    }
    private void Destruction()
    {
        col.enabled = false;

        Destroy(Wall);

        Wall_debris.SetActive(true);
        Destroy(Wall_debris, DestroyTime);
    }
}
