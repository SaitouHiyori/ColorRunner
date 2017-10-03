using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

    private ParticleSystem particle;
    public static bool bulletFire = false;
    public Animator animator;

    // Use this for initialization
    void Start ()
    {
        particle = GetComponent<ParticleSystem>();

        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Flag)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                particle.Play();
            }
        }
    }
}
