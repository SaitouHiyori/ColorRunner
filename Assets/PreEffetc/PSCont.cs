using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSCont : MonoBehaviour
{
    private ParticleSystem particle;
    // Use this for initialization
    void Start()
    {
        particle = GetComponent<ParticleSystem>();

        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            particle.Play();
        }
    }
}
