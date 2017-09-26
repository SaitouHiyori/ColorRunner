using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItamGet : MonoBehaviour {

    private ParticleSystem particle;

    // Use this for initialization
    void Start () {
        particle = GetComponent<ParticleSystem>();

        particle.Stop();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.G))
        {
            particle.Play();
        }
    }
}
