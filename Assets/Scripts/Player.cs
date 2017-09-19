using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]

public class Player : MonoBehaviour {
    //上下端
    public float TopLimmite;
    public float UnderLimmite;

    //ガソリン
    public static float GasolineTank;//現在ガソリン量
    public float UseGasoline;//ガソリン消費量
    public static float MaxGasoline = 100;//ガソリン最大値
    public float Gasoline{
        set{
            GasolineTank = value;
        }
        get{
            return GasolineTank;
        }
    }

    //弾丸
    public GameObject BulletPre;//弾丸プレファブ
    private GameObject BulletObj;//弾丸インスタンス
    public Paint.Name AttackColor;//発射する弾の色

    //移動位置
    private Vector3[] MovePos = new Vector3[3] { new Vector3(-8,6,0), new Vector3(-8,1,0), new Vector3(-8,-4,0) };
    private static Transform PlayerTransform;

    //Audio
    private AudioSource AudioSource;
    public AudioClip SoundEfect;

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

    public static void AddGasoline(float HowMenyGasoline){
        //ガソリン補充
        GasolineTank += HowMenyGasoline;
        //ガソリンは一定量までしか入らない
        if (GasolineTank > MaxGasoline){
            GasolineTank = MaxGasoline;
        }
    }//ガソリン補充メソッド


	void Awake () {
        Gasoline = MaxGasoline;
        PlayerTransform = GameObject.FindWithTag("Player").transform;
        AudioSource = GetComponent<AudioSource>();

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

        if (GameManager.Flag){
            GUI.Label(new Rect(0, 0, 100, 100), Score, Style);
            GUI.Label(new Rect(0, 40, 100, 100), GasolineMater, Style);
        }

    }
}
