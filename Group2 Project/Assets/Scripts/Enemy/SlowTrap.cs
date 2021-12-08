using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrap : MonoBehaviour
{
    GameObject player;

    Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }
    void OnTriggerEnter()
    {
        //vector = player.GetComponent<CharacterMove>().moveDirection;
        //player.GetComponent<CharacterMove>().moveDirection.x -= 2 * vector.x;
        //player.GetComponent<CharacterMove>().moveDirection.z -= 2 * vector.z;
    }

    void OnTriggerStay(Collider other) //진입중 속도 감속, 초당 5 피해
    {
        if (other.CompareTag("Player")) 
        { 
        int i = Random.Range(0, 10);
        other.GetComponent<CharacterMove>().speed = Mathf.Lerp(2, 5, i / 10);

        other.GetComponent<PlayerStatus>().PlayerHP -= 5 * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                other.GetComponent<CharacterMove>().speed = 12f;
            else 
                other.GetComponent<CharacterMove>().speed = 7f;
        }
    }

}
