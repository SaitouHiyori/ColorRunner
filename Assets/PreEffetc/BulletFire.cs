using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

    private ParticleSystem particle;
    public static bool bulletFire = false;

    // Use this for initialization
    void Start ()
    {
        particle = GetComponent<ParticleSystem>();

        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Get_GameFlag() == true)
        {
            if (bulletFire == true)
            {
                particle.Play();
            }
        }
    }
}
