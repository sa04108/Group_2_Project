using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gathering : MonoBehaviour
{
    [SerializeField]
    private int MaxHp;
    [SerializeField]
    private int Hp;
    [SerializeField]
    private int DropItemCount;
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
    [SerializeField]
    private List<GameObject> PrefabItem = new List<GameObject>();

    private GameObject deb;
    private GameObject Item;
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
        for (int i = 0; i < DropItemCount; i++)
        {
            ItemInstantiate();
        }// ���߿� Tool_Tier�� �̿��Ͽ� ���� �� �ִ� �ڿ��� �� ����.

        gather.SetActive(false);

        DebInstantiate();

        StartCoroutine("FalseActive");
        StartCoroutine("Reproduction");
    }

    private void DebInstantiate()
    {
        deb = Instantiate(gather_debris,gameObject.transform.position, Quaternion.identity);
    }
    private void ItemInstantiate()
    {
        Item = Instantiate(gatherItemPrefab, gameObject.transform.position, Quaternion.identity);
        PrefabItem.Add(Item);
    }
    IEnumerator FalseActive()
    {
        Destroy(deb, DestroyTime);
        yield return new WaitForSeconds(7.0f);

        for(int i=0;i<PrefabItem.Count;i++)
        {
            Destroy(PrefabItem[i]);
        }

        PrefabItem.Clear();
    }
    IEnumerator Reproduction()
    {
        yield return new WaitForSeconds(5.0f);
        col.enabled = true;
        Hp = MaxHp;
        gather.SetActive(true);
    }    
}
