using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBreath : MonoBehaviour
{
    ParticleSystem ps;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();
    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private PlayerStatus playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("col");
        if (other.tag == "Player")
        {
            playerStatus.PlayerHP -= 1;
        }
    }

    private void OnParticleTrigger()
    {
            
    }

    
}
