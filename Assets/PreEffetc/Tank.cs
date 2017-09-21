using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    public Animator animator;
    public static bool burrelbuck = false;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //animation
        if (GameManager.Get_GameFlag() == true)
        {
            if (burrelbuck == true)
            {
                animator.SetBool("fire", true);
            }
            else
            {
                animator.SetBool("fire", false);
            }
        }
	}
}
