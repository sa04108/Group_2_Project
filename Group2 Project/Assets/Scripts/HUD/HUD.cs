using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public Image playerHpGauge;
    public Image monsterHPGauge;

    // Update is called once per frame
    void Update()
    {
        playerHpGauge.fillAmount = playerStatus.PlayerHP / 100;
    }

    public void RenewMonsterHPGauge(MonsterStats stats)
    {
        monsterHPGauge.fillAmount = (float)stats.HP / (float)stats.FullHp;
    }
    public void RenewDragonHPGauge(DragonStatus stats)
    {
        monsterHPGauge.fillAmount = (float)stats.HP / (float)stats.FullHP;
        
    }
}
