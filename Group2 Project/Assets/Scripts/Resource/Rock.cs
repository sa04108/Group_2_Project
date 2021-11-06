using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int Hp;
    [SerializeField]
    private float DestroyTime;
    [SerializeField]
    private SphereCollider col;

    [SerializeField]
    private GameObject rock;
    [SerializeField]
    private GameObject rock_debris;
    [SerializeField]
    private GameObject rockItemPrefab;

    private int Tool_Tier;
    public void Mining()
    {
        Hp--; // 도구 티어에 따라 Hp -= Tier;

        if(Hp<=0)
        {
            Destruction();
        }
    }

    private void Destruction()
    {
        col.enabled = false;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(rockItemPrefab, rock.transform.position, Quaternion.identity);
        }// 나중에 Tool_Tier를 이용하여 얻을 수 있는 자원의 수 변경.

        Destroy(rock);

        rock_debris.SetActive(true);
        Destroy(rock_debris, DestroyTime);
    }
}
