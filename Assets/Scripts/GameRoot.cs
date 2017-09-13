using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour {

    public static float ChangeTimer;//経過時間
    public float ChangeInterval;//色変更間隔

    //道
    public static GameObject[] Rote = new GameObject[3];
    public GameObject[] Interface_Rote;

    private CameraController CameraController;

    public static void RoteBehind(){
        //全ての道を判定
        for (int i = 0; i < Rote.Length; i++){
            //背景色と同じ色の道は消失
            //異なる色の道は出現
            Rote[i].SetActive((i == CameraController.NowColorNum) ? false : true);
        }

        ChangeTimer = 0;//タイマーリセット
    }//道消失出現メソッド

	void Awake () {
        CameraController = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();

        //道設定
        for (int i = 0; i < Interface_Rote.Length; i++){
            Rote[i] = Interface_Rote[i];//オブジェクト登録
            Rote[i].GetComponent<Renderer>().material.color = CameraController.UseColor[i];
        }

        ChangeTimer = 0;//タイマー初期化
    }
	
	void Update () {
        ChangeTimer += Time.deltaTime;

        if(ChangeTimer >= ChangeInterval && !CameraController.IsFlash){//点滅開始
            CameraController.ColorChanger();
        }
	}
}