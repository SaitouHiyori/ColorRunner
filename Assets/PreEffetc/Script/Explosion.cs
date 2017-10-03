﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float multiplier = 1;


    private void Start()
    {
        var systems = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem system in systems)
        {
            ParticleSystem.MainModule mainModule = system.main;
            mainModule.startSizeMultiplier *= multiplier;
            mainModule.startSpeedMultiplier *= multiplier;
            mainModule.startLifetimeMultiplier *= Mathf.Lerp(multiplier, 1, 0.5f);
            system.Clear();
            system.Play();
        }
    }
}