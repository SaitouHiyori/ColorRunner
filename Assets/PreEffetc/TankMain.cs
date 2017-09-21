using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMain : MonoBehaviour {

    public　static bool Tankdown = false;
    public Animator animator;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Get_GameFlag() == true)
        {
            //土煙
            if (Tankdown == true)
            {
                PSCont.Smoke = false;
                animator.SetBool("Tank_Down", true);
            }
            else if (Tankdown == false)
            {
                PSCont.Smoke = true;
                animator.SetBool("Tank_Down", false);
            }


            //射撃
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                animator.SetBool("Tank_Fire", true);
                BulletFire.bulletFire = true;
                Tank.burrelbuck = true;
                BulletFire.bulletFire = true;
            }
            else
            {
                animator.SetBool("Tank_Fire", false);
                BulletFire.bulletFire = false;
                Tank.burrelbuck = false;
                BulletFire.bulletFire = false;
            }
        }
        else
        {
            PSCont.Smoke = false;
            animator.SetBool("Tank_Down", false);
            animator.SetBool("Tank_Fire", false);
        }
    }
}
