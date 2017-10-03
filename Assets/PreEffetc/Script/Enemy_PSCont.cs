using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PSCont : MonoBehaviour {

    private ParticleSystem particle;
    public bool EnemySmoke = false;

    // Use this for initialization
    void Start()
    {
        particle = GetComponent<ParticleSystem>();

        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemySmoke == true)
        {
            particle.Play();
        }
        else {
            particle.Stop();
        }
    }
}
