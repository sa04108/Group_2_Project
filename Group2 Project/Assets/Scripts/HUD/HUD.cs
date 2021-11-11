using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public Image playerHpGauge;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerHpGauge.fillAmount = playerStatus.PlayerHP / 100;
    }
}
