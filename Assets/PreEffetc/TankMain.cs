using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMain : MonoBehaviour {

    public　static bool IsFall = false;
    public static bool IsShot = false;
    public Animator Animator;


	void Update () {
        if (GameManager.Flag){
            //土煙
            if (IsFall){
                PSCont.Smoke = false;
                Animator.SetBool("Tank_Down", true);
            }
            else{
                PSCont.Smoke = true;
                Animator.SetBool("Tank_Down", false);
            }

            //射撃
            if (IsShot){
                Animator.SetBool("Tank_Fire", true);
                BulletFire.bulletFire = true;
                Tank.burrelbuck = true;
                BulletFire.bulletFire = true;
                IsShot = false;
            }
            else{
                Animator.SetBool("Tank_Fire", false);
                BulletFire.bulletFire = false;
                Tank.burrelbuck = false;
                BulletFire.bulletFire = false;
            }
        }

        else{
            PSCont.Smoke = false;
            Animator.SetBool("Tank_Down", false);
            Animator.SetBool("Tank_Fire", false);
        }
    }
}
