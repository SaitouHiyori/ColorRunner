using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class ItamGet : MonoBehaviour {

    public float DestroyTime;

    private ParticleSystem particle;

    public void ParticlePlay(){
        particle.Play();
    }

    // Use this for initialization
    private void Awake () {
        particle = GetComponent<ParticleSystem>();
        //particle.Play();
        Destroy(this.gameObject, DestroyTime);
    }

}
