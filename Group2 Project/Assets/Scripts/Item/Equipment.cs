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

    public int equipTier;//��� Ƽ��
    public int damage;//���Ϳ��� �ִ� ������
    public int loggingPower;//���� ȿ��
    public int miningPower;//ä�� ȿ��
    public int durability;//������ �� ��ź ����
}
