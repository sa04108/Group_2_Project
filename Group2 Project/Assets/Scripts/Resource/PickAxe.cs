using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxe : MonoBehaviour
{
    public int Tier;
    [SerializeField]
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Rock")&&Player.GetComponent<CharacterAnimator>().isAttack)
        {
            other.GetComponent<Gathering>().Mining(Tier);
        }
        if (other.CompareTag("Iron") && Player.GetComponent<CharacterAnimator>().isAttack&&Tier>=2)
        {
            other.GetComponent<Gathering>().Mining(Tier);
        }
        if (other.CompareTag("Diamond") && Player.GetComponent<CharacterAnimator>().isAttack&&Tier>=3)
        {
            other.GetComponent<Gathering>().Mining(Tier);
        }
    }
}
