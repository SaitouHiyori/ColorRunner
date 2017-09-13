using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public enum ObjctJanle { Object, Button };
    public ObjctJanle Janle;//オブジェクトジャンル設定変数

    //プレイヤーオブジェクト用ステータス
    //上下端
    public float TopLimmite;
    public float UnderLimmite;

    //ガソリン
    public static float Gasoline;//現在ガソリン量
    public static float UseGasoline;//ガソリン消費量
    public static float MaxGasoline;//ガソリン最大値

    //移動ボタン用ステータス
    public int ColorNum;//色番号

    private Vector3[] MovePos = new Vector3[3] { new Vector3(-8,6,0), new Vector3(-8,1,0), new Vector3(-8,-4,0) };

    private static Transform PlayerTransform;

    public static void AddGasoline(float HowMenyGasoline){
        //ガソリン補充
        Gasoline += HowMenyGasoline;
        //ガソリンは一定量までしか入らない
        if (Gasoline > MaxGasoline){
            Gasoline = MaxGasoline;
        }
    }//ガソリン補充メソッド

	void Awake () {
        PlayerTransform = GameObject.FindWithTag("Player").transform;

        //プレイヤーオブジェクトは初期位置へ移動
        if (Janle == ObjctJanle.Object){
            PlayerTransform.position = MovePos[1];//初期位置：真ん中
        }

    }
	
	void Update () {
        if(Janle == ObjctJanle.Object){
            Vector3 NowPos = PlayerTransform.position;

            Gasoline -= UseGasoline * Time.deltaTime;//ガソリンを消費する
            //ガソリンがなくなると車は動かない
            if (Gasoline <= 0){
                GameManager.Set_GameFlag(false);
            }

            //下に落ちると上に行く
            if (NowPos.y <= UnderLimmite){
                NowPos.y = TopLimmite;
                PlayerTransform.position = NowPos;
            }

        }
    }

    public void MoveHere(){
        if(ColorNum != CameraController.NowColorNum){
            PlayerTransform.position = MovePos[ColorNum];
        }
    }

    void OnGUI(){
        string Score = "Score:" + GameManager.Get_GameScore();

        GUI.Label(new Rect(0, 0, 100, 100), Score);
    }
}
