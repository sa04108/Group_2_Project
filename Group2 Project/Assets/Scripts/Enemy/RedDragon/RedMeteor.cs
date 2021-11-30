using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMeteor : MonoBehaviour
{
    [Header("Meteor")]
    public Transform meteor;
    public Transform meteor1;
    public Transform meteorPos;
    public int MeteorCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void MeteorDrop()
    {
        //���׿� ���۵Ǹ� ���ڸ����� ���¢�� ����̶� isLook ������
        GetComponent<RedControl>().isLook = false;
        //���׿� ���� ������ ������ 3�ʰ� �̵�
        MeteorPosMove meteorPosMove = GameObject.Find("MeteorPos").GetComponent<MeteorPosMove>();
        meteorPosMove.MeteorPosMoveOn = true;

        InvokeRepeating("MeteorInstantiate", 0, 0.049f);
        
        
    }
    public void MeteorInstantiate()
    {
        
        //�����
        float randomFloat = Random.Range(1, 4);
        if (randomFloat >= 3)
        {

            Transform meteorIns = (Transform)Instantiate(meteor, meteorPos.position, transform.rotation);
        }
        else
        {

            Transform meteorIns = (Transform)Instantiate(meteor1, meteorPos.position, transform.rotation);
        }
        //� 60�� �߻�Ǹ� ����
        MeteorCount++;
        if (MeteorCount > 60)
        {
            CancelInvoke("MeteorInstantiate");
            
            MeteorPosMove meteorPosMove = GameObject.Find("MeteorPos").GetComponent<MeteorPosMove>();
            //���׿� ������ġ �̵� ����
            meteorPosMove.MeteorPosMoveOn = false;
            //���׿� ������ġ �ʱ�ȭ
            meteorPosMove.PositionReset();
            MeteorCount = 0;
            GetComponent<RedControl>().isLook = true;
        }



    }


}
