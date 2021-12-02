using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gathering : MonoBehaviour {
    ItemData itemDB;

    [SerializeField]
    private int MaxHp;
    [SerializeField]
    private int Hp;
    [SerializeField]
    private float DestroyTime;
    [SerializeField]
    private Collider col;
    [SerializeField]
    private GameObject HitEffect;

    [SerializeField]
    private GameObject gather;
    [SerializeField]
    private GameObject gather_debris;
    [SerializeField]
    private GameObject gatherItemPrefab;
    [SerializeField]
    private List<GameObject> PrefabItem = new List<GameObject>();

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip HitSound;
    [SerializeField]
    private AudioClip debrisSound;

    private GameObject deb;
    private GameObject Item;

    public void Start() {
        itemDB = ItemData.instance;
    }

    public void Mining(int damage) {
        audioSource.clip = HitSound;
        audioSource.Play();
        var HE = Instantiate(HitEffect, col.bounds.center, Quaternion.identity);
        Destroy(HE, DestroyTime);
        Hp -= damage; // 도구 티어에 따라 Hp -= Tier;
        if (Hp <= 0) {
            Destruction();
        }
    }

    private void Destruction() {
        audioSource.clip = debrisSound;
        audioSource.Play();
        col.enabled = false;
        for (int i = 0; i < 5; i++) {
            ItemInstantiate();
        }// 나중에 Tool_Tier를 이용하여 얻을 수 있는 자원의 수 변경.

        gather.SetActive(false);

        DebInstantiate();

        StartCoroutine("FalseActive");
        StartCoroutine("Reproduction");
    }

    private void DebInstantiate() {
        deb = Instantiate(gather_debris, gameObject.transform.position, Quaternion.identity);
    }
    private void ItemInstantiate() {
        if (gameObject.tag == "Wood") {
            gatherItemPrefab.GetComponent<DropItem>().SetItem(itemDB.itemDB[CommonDefine.RESOURCE_BRANCH]);
        }
        else if (gameObject.tag == "Rock") {
            gatherItemPrefab.GetComponent<DropItem>().SetItem(itemDB.itemDB[CommonDefine.RESOURCE_STONE]);
        }
        else if (gameObject.tag == "Diamond") {
            gatherItemPrefab.GetComponent<DropItem>().SetItem(itemDB.itemDB[CommonDefine.RESOURCE_DIAMOND]);
        }
        else if(gameObject.tag == "Iron") {
            gatherItemPrefab.GetComponent<DropItem>().SetItem(itemDB.itemDB[CommonDefine.RESOURCE_IRON_ORE]);
        }

        Item = Instantiate(gatherItemPrefab, gameObject.transform.position, Quaternion.identity);
        PrefabItem.Add(Item);
    }
    IEnumerator FalseActive() {
        Destroy(deb, DestroyTime);
        yield return new WaitForSeconds(7.0f);

        for (int i = 0; i < PrefabItem.Count; i++) {
            Destroy(PrefabItem[i]);
        }

        PrefabItem.Clear();
    }
    IEnumerator Reproduction() {
        yield return new WaitForSeconds(35.0f);
        col.enabled = true;
        Hp = MaxHp;
        gather.SetActive(true);
    }
}
