using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private Collider col;
    [SerializeField]
    private GameObject TrapImage;
    [SerializeField]
    private float Damage;
    [SerializeField]
    private GameObject Fx;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip HitSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStatus>().PlayerHP -= Damage;
            Instantiate(Fx, this.transform.position, Quaternion.identity);
            Destroy(Fx, 0.5f);
            Destroy(this.gameObject, 0.5f);
        }
    }


}
