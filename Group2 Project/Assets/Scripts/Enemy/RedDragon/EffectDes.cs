using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDes : MonoBehaviour
{
    private AudioSource MeteorExpSound;

    public AudioClip Exp1;
    public AudioClip Exp2;
    public AudioClip Exp3;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4f);
        MeteorExpSound = GetComponent<AudioSource>();
        MeteorExpSound.loop = false;
        MeteorExpSound.time = 0f;

        int playSound = Random.Range(0, 10);
        if(playSound <= 1)
        {
            playSound = Random.Range(0, 4);
            if (playSound == 1)
            {
                MeteorExpSound.clip = Exp1;
                MeteorExpSound.Play();

            }
            else if (playSound == 2)
            {
                MeteorExpSound.clip = Exp2;
                MeteorExpSound.Play();
            }

            else if (playSound == 3)
            {
                MeteorExpSound.clip = Exp3;
                MeteorExpSound.Play();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();
            playerStatus.Burning(3);
        }
    }
}
