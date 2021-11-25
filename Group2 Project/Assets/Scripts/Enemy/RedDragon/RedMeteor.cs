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

    public void MeteorPosMove()
    {


    }
    public void MeteorDrop()
    {
        //메테오 시작되면 제자리에서 울부짖는 모션이라 isChase 중지함
        GetComponent<RedControl>().isChase = false;
        //메테오 생성 포지션 앞으로 3초간 이동
        MeteorPosMove meteorPosMove = GameObject.Find("MeteorPos").GetComponent<MeteorPosMove>();
        meteorPosMove.MeteorPosMoveOn = true;

        InvokeRepeating("MeteorInstantiate", 0, 0.05f);
        
        
    }
    public void MeteorInstantiate()
    {
        //운석생성
        float randomFloat = Random.Range(1, 2);
        if (randomFloat >= 2)
        {

            Transform meteorIns = (Transform)Instantiate(meteor, meteorPos.position, transform.rotation);
        }
        else
        {

            Transform meteorIns = (Transform)Instantiate(meteor1, meteorPos.position, transform.rotation);
        }

        //운석 60개 발사되면 종료
        MeteorCount++;
        if(MeteorCount >= 60)
        {
            CancelInvoke("MeteorInstantiate");
            MeteorPosMove meteorPosMove = GameObject.Find("MeteorPos").GetComponent<MeteorPosMove>();
            //메테오 생성위치 이동 중지
            meteorPosMove.MeteorPosMoveOn = false;
            //메테오 생성위치 초기화
            meteorPosMove.PositionReset();
        }
        
        
    }


}
