using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    public Animator animator;

    Vector3 BarrelVec;
    float Barrel_Back = -20f;
    float Barrel_return = 2.0f;

    bool Barrelflag = true;
    int i;

    // Use this for initialization
    void Start () {
        BarrelVec = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //animation
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("fire", true);
        }
        else
        {
            animator.SetBool("fire", false);
        }
        //program
        if (Barrelflag = true && Input.GetKeyDown(KeyCode.DownArrow))
        {
            BarrelVec.z = Barrel_Back;
            transform.position = BarrelVec;
            Barrelflag = false;
            Debug.Log("false");
        }
        if (Barrelflag == false)
        {
            for (i = 0; i <= 10; i++)
            {
                BarrelVec.z += Barrel_return;
                transform.position = BarrelVec;
            }
            if (i >= 10)
            {
                Barrelflag = true;
                i = 0;
                Debug.Log("true");
            }
        }
	}
}
