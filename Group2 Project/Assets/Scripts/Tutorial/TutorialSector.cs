using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSector : MonoBehaviour
{
    [SerializeField]
    private GameObject TutorialPanel;
    [SerializeField]
    private Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            TutorialPanel.SetActive(true);
            col.enabled = false;
        }
    }
}
