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
        Hp -= damage; // ���� Ƽ� ���� Hp -= Tier;

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
        }// ���߿� Tool_Tier�� �̿��Ͽ� ���� �� �ִ� �ڿ��� �� ����.

        Destroy(gather);

        gather_debris.SetActive(true);
        Destroy(gather_debris, DestroyTime);
    }
}
