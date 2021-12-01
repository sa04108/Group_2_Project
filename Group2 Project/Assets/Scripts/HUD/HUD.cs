using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    PlayerStatus playerStatus;
    Coroutine coroutine;

    public Image playerHpGauge;
    public Image monsterHPGauge;

    private void Awake()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHpGauge.fillAmount = playerStatus.PlayerHP / 100;
    }

    public void RenewMonsterHPGauge(MonsterStats stats)
    {
        StopCoroutine(coroutine);
        coroutine = StartCoroutine(SetActiveGauge(stats.HP, stats.FullHp));
    }
    public void RenewDragonHPGauge(DragonStatus stats)
    {
        StopCoroutine(coroutine);
        coroutine = StartCoroutine(SetActiveGauge(stats.HP, stats.FullHP));
    }

    IEnumerator SetActiveGauge(int hp, int fullHp)
    {
        monsterHPGauge.transform.parent.gameObject.SetActive(true);
        monsterHPGauge.fillAmount = hp / (float)fullHp;

        yield return new WaitForSeconds(5.0f);

        monsterHPGauge.transform.parent.gameObject.SetActive(false);
    }
}
