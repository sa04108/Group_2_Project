using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftExecution : MonoBehaviour
{
    private Inventory inven;
    public Item item; // �䱸�Ǵ� �ڿ��� item ����
    [SerializeField]
    private int RequestCount;// �䱸�Ǵ� item�� ��
    [SerializeField]
    private int EquipmentNum;// ����� slot�� ����
    [SerializeField]
    private Sprite EquipmentImage; // ���â�� �� �̹���

    private void Start()
    {
        inven = Inventory.instance;
    }

    public void Crafting() // Craft ��ư�� ������ ���.
    {
        for (int i = 0; i < inven.SlotCnt; i++)
        {
            // ������ ���� �˻��ؼ� �ʿ��� ������ �̸� == �κ��丮�� �ִ� ������ �̸��� �ִ��� Ȯ��. ( item.Name string �̿� )
            // ���� Ȯ���� �Ǿ��ٸ� �ʿ��� �������� �� <= �κ��丮�� ������ ���� ��, Ȯ��.
            // ���� �Ϸ� �Ǿ��ٸ�, �κ��丮�� �ִ� �������� �� -= �ʿ��� �������� ��.
            // EquipmentSlot�� �ش��ϴ� Slot �����Ͽ� ���� ������ ����, �̹��� ��ȯ. or Player�� Equipment�� �����͸� ����
        }
    }
}
