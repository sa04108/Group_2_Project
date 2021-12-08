using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSync : MonoBehaviour
{
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audio.volume = AudioManager.Volume;
    }
}
