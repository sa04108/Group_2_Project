using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EQUIP_TYPE {
    SWORD,
    BOW,
    HAMMER,
    AXE,
    PICKAXE,
    BOMB,
    SHIELD
}

[System.Serializable]
public class Equipment
{
    public EQUIP_TYPE equipType;
    public string equipName;
    public GameObject equipPrefab;

    public Sprite equipImage;   

    public int equipTier;//장비 티어
    public int damage;//몬스터에게 주는 데미지
    public int loggingPower;//벌목 효율
    public int miningPower;//채광 효율
    public int durability;//내구도 및 폭탄 개수
}
