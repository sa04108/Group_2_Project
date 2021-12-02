using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorExplosion : MonoBehaviour
{
    private AudioSource MeteorSound;
    float dropDirX;
    float dropDirZ;
    public GameObject meteorEffect;
    float dropPlusZ;

    // Start is called before the first frame update
    void Start()
    {
        //흩뿌려주는 용
        dropDirX = Random.Range(-0.013f, 0.013f);
        dropDirZ = Random.Range(-0.013f, 0.013f);
        // 용 앞쪽으로 이동시켜주는 용
        dropPlusZ = 0.025f;

        MeteorSound = GetComponent<AudioSource>();
        MeteorSound.loop = false;
        MeteorSound.time = 0f;
        Invoke("MeteorSoundPlay", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dropDirX, 0, dropDirZ+dropPlusZ);

        //맵반경보다 멀리 날아가서 클론이 안 지워질 경우 대비
        if(this.transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            Instantiate(meteorEffect, transform.position, transform.rotation);
            Destroy(gameObject, 0.1f);
        }
        
    }
    public void MeteorSoundPlay()
    {
        int playSound = Random.Range(0, 10);
        if(playSound <= 1)
        {
            MeteorSound.Play();

        }
    }
}
