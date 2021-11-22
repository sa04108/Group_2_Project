using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    MeshRenderer mesh;
    Rigidbody rigidbody;
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Camera.main.transform.forward * 10;
        Invoke("Explode", 2.0f);
    }

    void Explode()
    {
        effect.SetActive(true);
        mesh.enabled = false;
    }
}
