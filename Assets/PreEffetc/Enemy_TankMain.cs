using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TankMain : MonoBehaviour
{

    public Animator Animator;

    //落下判定の取得
    public bool EnemyIsFallnow;
    public Enemy_PSCont PSCont;

    public void Start()
    {
        //PSCont = transform.parent.GetComponent<Enemy_PSCont>();

        Debug.Log(PSCont);

    }
void Update()
    {
        if (GameManager.Flag)//ゲーム中のみパーティクル再生
        {
            if(EnemyIsFallnow)//落下中
            {
                PSCont.EnemySmoke = false;//煙中断
                Animator.SetBool("Tank_Down", true);//落下アニメーション
            }
            else {
                PSCont.EnemySmoke = true;
                Animator.SetBool("Tank_Down", false);
            }
        }
        else {
            PSCont.EnemySmoke = false;
            Animator.SetBool("Tank_Down", false);
        }
    }
}
