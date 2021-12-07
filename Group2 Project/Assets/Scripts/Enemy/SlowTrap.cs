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

    void OnTriggerStay() //진입중 속도 감속, 초당 5 피해
    {

        int i = Random.Range(0, 10);
        player.GetComponent<CharacterMove>().speed = Mathf.Lerp(2, 5, i / 10);

        player.GetComponent<PlayerStatus>().PlayerHP -= 5 * Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<CharacterMove>().speed = 7f;
    }


}
