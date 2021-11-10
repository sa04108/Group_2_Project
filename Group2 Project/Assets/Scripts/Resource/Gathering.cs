using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gathering : MonoBehaviour
{
    [SerializeField]
    private int Hp;
    [SerializeField]
    private float DestroyTime;
    [SerializeField]
    private Collider col;

    [SerializeField]
    private GameObject gather;
    [SerializeField]
    private GameObject gather_debris;
    [SerializeField]
    private GameObject gatherItemPrefab;

    private int Tool_Tier;
    public void Mining(int damage)
    {
        Hp -= damage; // 도구 티어에 따라 Hp -= Tier;

        if (Hp <= 0)
        {
            Destruction();
        }
    }

    private void Destruction()
    {
        col.enabled = false;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(gatherItemPrefab, gather.transform.position, Quaternion.identity);
        }// 나중에 Tool_Tier를 이용하여 얻을 수 있는 자원의 수 변경.

        Destroy(gather);

        gather_debris.SetActive(true);
        Destroy(gather_debris, DestroyTime);
    }
}
