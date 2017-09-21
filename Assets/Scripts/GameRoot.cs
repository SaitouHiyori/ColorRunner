using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour {

    public static float ChangeTimer;//経過時間
    public float ChangeInterval;//色変更間隔

    //道
    public static GameObject[] Rote = new GameObject[3];
    public GameObject[] Interface_Rote;//外部入力用

    private CameraController CameraController;

    private bool GameF;

    //各種オブジェクト
    private Player Player;
    public ItemFactory ItemFactory;
    public SceneRuler SceneRuler;

    public static void RoteBehind(){
        //全ての道を判定
        for (int i = 0; i < Rote.Length; i++){
            //背景色と同じ色の道は消失
            //異なる色の道は出現
            Rote[i].SetActive((i == (int)CameraController.NowBackgroundColor) ? false : true);
        }

        ChangeTimer = 0;//タイマーリセット
    }//道消失出現メソッド

    private void GameOver(){
        SceneRuler.SceneChange();
        GameF = false;
    }

	void Awake () {
        GameManager.Flag = true;
        GameManager.Reset_GameScore();
        GameF = GameManager.Flag;

        //各種オブジェクト取得
        Player = GameObject.FindWithTag("Player").GetComponent<Player>();
        CameraController = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();

        //道設定
        for (int i = 0; i < Interface_Rote.Length; i++){
            Rote[i] = Interface_Rote[i];//オブジェクト登録
            Rote[i].GetComponent<Renderer>().material.color = Paint.GetColor(Paint.Int2Name(i));//色設定
        }

        //RoteBehind();
    }
	
    private void Start(){
        RoteBehind();
    }

	void Update () {
        if (GameManager.Flag) {
        ChangeTimer += Time.deltaTime;//時間計測

            if (ChangeTimer >= ChangeInterval && !CameraController.IsFlash){//点滅開始
                CameraController.ColorChanger();
            }

            Player.Move();
            ItemFactory.Move();
        }
        else{
            if (GameF){
                GameOver();
            }
        }
	}
}