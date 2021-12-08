using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLootingSound : MonoBehaviour
{
    [SerializeField] AudioClip lootingSound;
    [SerializeField] AudioClip healingSound;
    AudioSource audio;
    void OnEnable()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void InitPrefab(string type) {
        audio = gameObject.GetComponent<AudioSource>();
        if (type == "Portion") {
            audio.pitch = 1.0f;
            audio.volume = 1.0f;
            audio.clip = healingSound;
            StartCoroutine(playSound(healingSound));
        }
        else if(type == "dropItem") {
            audio.pitch = 0.57f;
            audio.volume = 0.5f;
            audio.clip = lootingSound;
            StartCoroutine(playSound(lootingSound));
        }
    }

    private IEnumerator playSound(AudioClip clip) {
        float length = clip.length;

        audio.clip = clip;
        audio.Play();
        yield return new WaitForSeconds(length);
        Destroy(gameObject);
    }

}
