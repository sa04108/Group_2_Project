using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAudio : MonoBehaviour
{

    private AudioSource DragonSoundPlayer;
    private AudioSource DragonSoundPlayer1;
    public AudioClip DragonDeath;
    public AudioClip DragonFootStep1;
    public AudioClip DragonFootStep2;
    public AudioClip DragonFootStep3;
    public AudioClip DragonTakeOff;
    public AudioClip DragonBreath;
    public AudioClip DragonFlying1;
    public AudioClip DragonFlying2;
    public AudioClip DragonFlying3;
    public AudioClip DragonFlying4;
    public AudioClip DragonGetHit1;
    public AudioClip DragonGetHit2;
    public AudioClip DragonScreaming;
    public AudioClip DragonShortScreaming;
    public AudioClip DragonDefend;
    public AudioClip DragonStepBack;
    public AudioClip DragonBite;
    public AudioClip DragonJumpBite;

    // Start is called before the first frame update
    void Start()
    {
        DragonSoundPlayer = GetComponent<AudioSource>();
        DragonSoundPlayer1 = transform.GetChild(0).gameObject.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRedDeath()
    {
        DragonSoundPlayer.clip = DragonDeath;
        DragonSoundPlayer.loop = false;
        DragonSoundPlayer.time = 0;
        DragonSoundPlayer.Play();
    }

    public void PlayRedFootStep()
    {
        int randomNum = Random.Range(1, 4);
        if(randomNum == 1)
        {
            DragonSoundPlayer1.clip = DragonFootStep1;
        }
        else if(randomNum == 2)
        {
            DragonSoundPlayer1.clip = DragonFootStep2;
        }
        else if(randomNum == 3)
        {
            DragonSoundPlayer1.clip = DragonFootStep3;
        }


        DragonSoundPlayer1.loop = false;
        DragonSoundPlayer1.time = 0;
        DragonSoundPlayer1.Play();


    }

    

    public void PlayRedTakeOff()
    {
        DragonSoundPlayer.Stop();
        DragonSoundPlayer.clip = DragonTakeOff;
        DragonSoundPlayer.loop = false;
        DragonSoundPlayer.time = 0;
        DragonSoundPlayer.Play();
    }
    public void PlayRedBreath()
    {
        DragonSoundPlayer.clip = DragonBreath;
        DragonSoundPlayer.loop = false;
        DragonSoundPlayer.time = 0;
        DragonSoundPlayer.Play();
    }
    public void PlayRedFlying()
    {
        int randomNum = Random.Range(1, 5);
        if (randomNum == 1)
        {
            DragonSoundPlayer1.clip = DragonFlying1;
        }
        else if (randomNum == 2)
        {
            DragonSoundPlayer1.clip = DragonFlying2;
        }
        else if (randomNum == 3)
        {
            DragonSoundPlayer1.clip = DragonFlying3;
        }
        else if (randomNum == 4)
        {
            DragonSoundPlayer1.clip = DragonFlying4;
        }
        DragonSoundPlayer1.loop = false;

        DragonSoundPlayer1.time = 0;
        DragonSoundPlayer1.Play();
    }
    public void PlayRedGetHit()
    {
        DragonSoundPlayer.Stop();
        int randomNum = Random.Range(1, 5);
        if (randomNum == 1)
        {
            DragonSoundPlayer.clip = DragonGetHit1;
        }
        else if (randomNum == 2)
        {
            DragonSoundPlayer.clip = DragonGetHit2;
        }
        
        DragonSoundPlayer.loop = false;
        
        DragonSoundPlayer.time = 0;
        DragonSoundPlayer.Play();

    }
    public void PlayRedScreaming()
    {
        DragonSoundPlayer.clip = DragonScreaming;
        DragonSoundPlayer.loop = false;
        DragonSoundPlayer.time = 0;
        DragonSoundPlayer.Play();
    }
    public void PlayRedShortScreaming()
    {
        DragonSoundPlayer.clip = DragonShortScreaming;
        DragonSoundPlayer.loop = false;
        DragonSoundPlayer.time = 0;
        DragonSoundPlayer.Play();
    }
    public void PlayRedDefend()
    {
        DragonSoundPlayer.Stop();
        DragonSoundPlayer.clip = DragonDefend;
        DragonSoundPlayer.loop = false;
        DragonSoundPlayer.time = 0;
        DragonSoundPlayer.Play();
    }
    public void PlayRedStepBack()
    {
        DragonSoundPlayer.Stop();
        DragonSoundPlayer.clip = DragonStepBack;
        DragonSoundPlayer.loop = false;
        DragonSoundPlayer.time = 0;
        DragonSoundPlayer.Play();
    }

    public void PlayRedBite()
    {
        DragonSoundPlayer.Stop();
        DragonSoundPlayer.clip = DragonBite;
        DragonSoundPlayer.loop = false;
        DragonSoundPlayer.time = 0;
        DragonSoundPlayer.Play();
    }
    public void PlayRedJumpBite()
    {
        DragonSoundPlayer.Stop();
        DragonSoundPlayer.clip = DragonJumpBite;
        DragonSoundPlayer.loop = false;
        DragonSoundPlayer.time = 0;
        DragonSoundPlayer.Play();
    }
}
