using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    int count;
    [SerializeField]AudioClip[] footstep;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FootStepSound() {
        
        audio.clip = footstep[count];
        count++;
        if(count >= footstep.Length) {
            count = 0;
        }
        audio.Play();
        Debug.Log("Footstep");
    }
}
