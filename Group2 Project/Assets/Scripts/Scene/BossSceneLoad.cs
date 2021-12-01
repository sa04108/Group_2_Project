using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSceneLoad : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Boss");
        }
        
    }
}
