using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static float volume = 0.2f;
    public static float Volume { get => volume; }

    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = volume;
    }

    public void SetVolume(float vol)
    {
        volume = vol;
    }
}
