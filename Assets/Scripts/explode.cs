using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {
    private AudioSource ExplodeSound;

    void Awake()
    {
        ExplodeSound = GetComponent<AudioSource>();
    }

    public void _SoundPlay()
    {
        ExplodeSound.Play();
    }
}
