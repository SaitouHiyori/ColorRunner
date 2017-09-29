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

    //移動スコア
    private int RunScore;//走った距離
    public float RunScoreInterval;//スコア取得間隔

    //弾丸
    public float ShotInterval;
    public bool ShotFlag;
    public GameObject BulletPre;//弾丸プレファブ
    private GameObject BulletObj;//弾丸インスタンス
    public Paint.Name AttackColor;//発射する弾の色
    public Vector3 BulletShotPos;

    //移動位置
    private Vector3[] MovePos = new Vector3[3] { new Vector3(-8, 7, 0), new Vector3(-8, 4, 0), new Vector3(-8, 0, 0) };
    private static Transform PlayerTransform;

    //Audio
    private AudioSource ShotSound;
    //public AudioClip ShotSound;
    //public float GetItemSETime;//SE再生時間
    //private static float SETimer;
    //private float BeforTimer;
    //private bool IsMute;

    //ItemGetIcon
    public GameObject ItemGetIcon;
    public Vector3 ItemGetIconPos;
    public Vector3 ItemGetIconRoll;

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

    private IEnumerator ShotIntervalChacker(){
        ShotFlag = false;
        yield return new WaitForSeconds(ShotInterval);
        ShotFlag = true;
    }

    public void Shot(){
        if (ShotFlag){
            BulletObj = (GameObject)Instantiate(BulletPre, transform.position + BulletShotPos, Quaternion.identity);//弾生成
            BulletObj.GetComponent<Bullet>().SetColor(AttackColor);//攻撃色設定
            TankMain.IsShot = true;
            ShotSound.Play();
            StartCoroutine(ShotIntervalChacker());
        }

    }//攻撃メソッド

    public static void AddGasoline(float HowMenyGasoline){
        //ガソリン補充
        GasolineTank += HowMenyGasoline;
        //ガソリンは一定量までしか入らない
        if (GasolineTank > MaxGasoline){
            GasolineTank = MaxGasoline;
        }
    }//ガソリン補充メソッド

    private IEnumerator Running(){
        while (true){
            if (!GameManager.Flag){
                GameManager.Score = RunScore;
                break;
            }
            yield return new WaitForSeconds(RunScoreInterval);
            RunScore++;//スコア加算
        }
    }

    public void IsItemGet(){
        Instantiate(ItemGetIcon, transform.position + ItemGetIconPos, Quaternion.Euler(ItemGetIconRoll));
    }

    void Awake () {
        Gasoline = MaxGasoline;
        PlayerTransform = GameObject.FindWithTag("Player").transform;
        ShotSound = GetComponent<AudioSource>();

        //プレイヤーオブジェクトは初期位置へ移動
        PlayerTransform.position = MovePos[1];//初期位置：真ん中
    }
	
    private void Start(){
        StartCoroutine(Running());//走り出す
    }

	public void Move () {


            Gasoline -= UseGasoline * Time.deltaTime;//ガソリンを消費する
            //ガソリンがなくなると車は動かない
            if (Gasoline <= 0){
            GameManager.Flag = false;
            }

        Vector3 NowPos = PlayerTransform.position;

        //下に落ちると上に行く
        if (NowPos.y <= UnderLimmite){
                NowPos.y = TopLimmite;
                PlayerTransform.position = NowPos;
            }

        TankMain.IsFall = (GetComponent<Rigidbody>().velocity.y < 0) ? true : false;

    }

    void OnGUI(){
        string Score = "Score:" + GameManager.Score;
        string RunAway = string.Format("RunAway:{0}m", RunScore);
        string GasolineMater = string.Format("Gasoline:{0:###}%", Gasoline / MaxGasoline * 100);

        GUIStyle Style = new GUIStyle();
        Style.fontSize = 30;

        if (GameManager.Flag){
            GUI.Label(new Rect(0, 0, 100, 100), Score, Style);
            GUI.Label(new Rect(0, 30, 100, 100), RunAway, Style);
            GUI.Label(new Rect(0, 60, 100, 100), GasolineMater, Style);
        }

    }
}