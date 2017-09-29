using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //背景色
    private Paint.Name[] BackgroundColor = new Paint.Name[3];//一覧
    public static Paint.Name NowBackgroundColor;//現在の背景色
    public Paint.Name InterfaceBackgroundColor;

    public float[] FadeTime;//フェードアウト・インにかかる時間
    public int[] FadeCount;//フェード秒数毎の往復回数

    public bool IsFlash;//点滅中判定フラグ

    private Camera Camera;

    private IEnumerator Flashing(Paint.Name NowColorName, Paint.Name NewColorName){
        //切り替える２色を取得
        Color NowColor = Paint.GetColor(NowColorName);
        Color NewColor = Paint.GetColor(NewColorName);

        //変化中の色を保存
        Color ChangeColor = new Color();

        float FadeTimer = new float();//フェード中経過時間
        float MoveN = FadeTimer / FadeTime[0];//変化の割合

        for (int i = 0; i < FadeCount.Length; i++){
            for (int j = 0; j < FadeCount[i]; j++){
                while (MoveN < 1){//Now2New
                    ChangeColor = NowColor * (1 - MoveN) + NewColor * MoveN;
                    Camera.backgroundColor = ChangeColor;
                    FadeTimer += Time.deltaTime;
                    MoveN = FadeTimer / FadeTime[i];
                    yield return new WaitForSeconds(Time.deltaTime);
                }
                while (MoveN > 0){//New2Now
                    ChangeColor = NowColor * (1 - MoveN) + NewColor * MoveN;
                    Camera.backgroundColor = ChangeColor;
                    FadeTimer -= Time.deltaTime;
                    MoveN = FadeTimer / FadeTime[i];
                    yield return new WaitForSeconds(Time.deltaTime);
                }
            }
        }
        while (MoveN < 1){//Now2New
            ChangeColor = NowColor * (1 - MoveN) + NewColor * MoveN;
            Camera.backgroundColor = ChangeColor;
            FadeTimer += Time.deltaTime;
            MoveN = FadeTimer / FadeTime[FadeTime.Length - 1];//配列最後尾のデータを参照
            yield return new WaitForSeconds(Time.deltaTime);
        }

    }//点滅メソッド

    private IEnumerator Flash(Paint.Name NowColor, Paint.Name NewColor){
        //点滅開始
        IsFlash = true;
        //NowBackgroundColor = Paint.Name.Change;

        //点滅メソッド呼出
        yield return StartCoroutine(Flashing(NowColor, NewColor));

        NowBackgroundColor = NewColor;//新しい背景色を登録
        GameRoot.RoteBehind();//道を出現・消滅させる
        IsFlash = false;//点滅終了
    }

    public  void ColorChanger(){
        Paint.Name NewColor;//変更先の色

        //変更先の色を決定
        while (true){
            NewColor = BackgroundColor[Random.Range(0, BackgroundColor.Length)];//背景色一覧からランダムに決定
            if (NewColor != NowBackgroundColor) {
                break;
            }//現在の背景色と異なる色を選択する
        }

        //点滅メソッド呼出
        StartCoroutine(Flash(NowBackgroundColor, NewColor));
    }//背景色変更メソッド

    private void Awake(){
        //メインカメラ取得
        Camera = GetComponent<Camera>();

        //使用する背景色を取得
        for (int i = 0; i < BackgroundColor.Length; i++){
            BackgroundColor[i] = Paint.Int2Name(i);
        }

    }

    private void Start(){
        //初期背景色設定
        //NowBackgroundColor = Paint.Int2Name(Random.Range(0, 3));
        NowBackgroundColor = Paint.Name.White;
        Camera.backgroundColor = Paint.GetColor(NowBackgroundColor);
        //ColorChanger();
    }

    private void Update(){
        //InterfaceBackgroundColor = NowBackgroundColor;
    }

}