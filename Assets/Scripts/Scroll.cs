using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    /*
    背景をスクロールさせる
    スクロール開始地点と終了地点を設定
    終了地点に移動したら開始地点に移動

    開始地点に移動するたびに上下の場所をランダムに変更する
    開始地点に移動するメソッド
    スクロールするメソッド
    */
    
    public float Speed; //スクロール速度

    //ランダム位置生成上限・下限
    public float HeighEnd; //上限
    public float LowEnd;   //下限

    public float ScrollStart; //スクロール開始地点
    public float ScrollEnd;   //スクロール終了地点

    void Scrolling(){
        //スクロールメソッド

        //ゲーム中のみスクロール
        if (GameManager.Get_GameFlag() == false){
            return;
        }

        transform.position -= new Vector3(Speed, 0, 0);
    }

    void ReturnToStart(){
        //スクロール開始地点移動メソッド
        float yPos = Random.Range(LowEnd, HeighEnd);
        Vector3 ReturnPos = new Vector3(ScrollStart, yPos, 1);
        transform.position = ReturnPos;
    }

	void Start () {
        GameManager.Set_GameFlag(true);
	}
	
	void Update () {
        //スクロールさせる
        Scrolling();

        //スクロール終了地点を過ぎたら開始地点に戻す
        if(transform.position.x < ScrollEnd){
            ReturnToStart();
        }
	}
}
