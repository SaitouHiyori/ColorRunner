using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    //上下端
    public float TopLimmite;
    public float UnderLimmite;

    //ガソリン
    public float Gasoline;//現在ガソリン量
    public float UseGasoline;//ガソリン消費量
    public float MaxGasoline;//ガソリン最大値

    //弾丸
    public GameObject BulletPre;//弾丸プレファブ
    private GameObject BulletObj;//弾丸インスタンス
    public Paint.Name AttackColor;//発射する弾の色

    //移動位置
    private Vector3[] MovePos = new Vector3[3] { new Vector3(-8,6,0), new Vector3(-8,1,0), new Vector3(-8,-4,0) };
    private static Transform PlayerTransform;

    //ボタンアクション
    public void RoteChange(Paint.Name RoteColor){
        //背景色と同じ色の道には移動できない
        if(RoteColor != CameraController.NowBackgroundColor){
            int RoteNum = (int)RoteColor;//キャスト変換
            PlayerTransform.position = MovePos[RoteNum];//移動
        }
    }//道移動メソッド

    public void SetAttackColor(Paint.Name AttackColorName){
        AttackColor = AttackColorName;//キャスト変換
    }

    public void Shot(){
        BulletObj = (GameObject)Instantiate(BulletPre,transform.position,Quaternion.identity);//弾生成
        BulletObj.GetComponent<Bullet>().SetColor(AttackColor);//攻撃色設定
    }//攻撃メソッド

    public void AddGasoline(float HowMenyGasoline){
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
        PlayerTransform.position = MovePos[1];//初期位置：真ん中

    }
	
	public void Move () {
            Vector3 NowPos = PlayerTransform.position;

            Gasoline -= UseGasoline * Time.deltaTime;//ガソリンを消費する
            //ガソリンがなくなると車は動かない
            if (Gasoline <= 0){
            GameManager.Flag = false;
            }

            //下に落ちると上に行く
            if (NowPos.y <= UnderLimmite){
                NowPos.y = TopLimmite;
                PlayerTransform.position = NowPos;
            }

    }

    void OnGUI(){
        string Score = "Score:" + GameManager.Score;
        string GasolineMater = string.Format("Gasoline:{0:###}%", Gasoline / MaxGasoline * 100);

        GUIStyle Style = new GUIStyle();
        Style.fontSize = 40;

        GUI.Label(new Rect(0, 0, 100, 100), Score,Style);
        GUI.Label(new Rect(0,40,100,100), GasolineMater,Style);
    }
}
