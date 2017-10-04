﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlesmoke : MonoBehaviour {

    private ParticleSystem particle;
    public static bool Smoke = false;

    // Use this for initialization
    void Start()
    {
        particle = GetComponent<ParticleSystem>();

        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        particle.Play();
    }
}
