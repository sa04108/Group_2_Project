using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float vol)
    {
        AudioSource[] audioSource = FindObjectsOfType<AudioSource>();
        foreach (var audio in audioSource)
        {
            audio.volume = vol / 2; // max 0.5
        }
    }
}
