using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static Color[] UseColor = new Color[3];//背景色一覧　配列番号で管理する
    public static int NowColorNum;//現在の背景色

    public static int FlashCount;//点滅回数　奇数回が望ましい
    public static float FlashTime;//点滅時間

    public bool IsFlash;//点滅中判定フラグ

    private static Camera Camera;

    //外部設定用変数
    public Color[] Interface_UseColor = new Color[3];
    public int Interface_FlashCount;
    public float Interface_FlashTime;

    private IEnumerator Flashing(int NowNum, int NewNum){
        IsFlash = true;//点滅開始

        //切り替える２色を取得
        Color NowColor = UseColor[NowNum];
        Color NewColor = UseColor[NewNum];

        //点滅
        int Swicher = 0;//点滅切替用変数
        for (int i = 0; i < FlashCount; i++){
            if (i > 0){
                yield return new WaitForSeconds(FlashTime);//１回目は待たない
            }
            //色切替
            Camera.backgroundColor = (Swicher == 0) ? NewColor : NowColor;
            Swicher = (Swicher == 0) ? 1 : 0;

        }
        NowColorNum = NewNum;
        GameRoot.RoteBehind();
        IsFlash = false;//点滅終了

    }//点滅メソッド

    private IEnumerator Flash(int NowNum, int NewNum){
        IsFlash = true;
        yield return StartCoroutine(Flashing(NowNum, NewNum));
        IsFlash = false;
    }

    public  void ColorChanger(){
        //現在の背景色と異なる色を選択する
        int NewColorNum;
        while (true){
            NewColorNum = Random.Range(0, UseColor.Length);
            if (NewColorNum != NowColorNum) {
                break;
            }
        }
        StartCoroutine(Flash(NowColorNum, NewColorNum));
    }//色変更メソッド

    private void Awake(){
        //Camera取得
        Camera = GetComponent<Camera>();

        for (int i = 0; i < UseColor.Length; i++){
            UseColor[i] = Interface_UseColor[i];
        }
        FlashCount = Interface_FlashCount;
        FlashTime = Interface_FlashTime;

        FlashCount = (FlashCount % 2 == 0) ? FlashCount + 1 : FlashCount;//点滅回数は奇数回
    }
 
}
