using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    private Sprite Image;//장비창에 사용할 이미지
    private int Tier; // Tool or Weapon의 등급

    // 장비창에 들어가는 순서를 고정시켜 그에 맞는 Tier를 읽어와서 무기를 갱신 시키는 로직을 생각해 봄.
    // ex) 장비 1번째 칸은 무조건 '칼' -> EquipmentSlot[1].Tier = 1이면 sword의 tier = 1 -> 나중에 장비의 능력치 조절.
}
