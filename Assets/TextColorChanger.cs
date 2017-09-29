using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChanger : MonoBehaviour {

    public Color StartColor;
    public Color EndColor;
    public float ChangeInterval;//変化にかかる時間
    private float ChangeTimer;//変化計測時間

    private Text Text;

    private IEnumerator ColorChanger(){
        //色変更に使用する変数を宣言
        Color NewColor = new Color();//変更中の色
        float MoveN = new float();//変化の割合  

        while (ChangeTimer < ChangeInterval){
            MoveN = ChangeTimer / ChangeInterval;//変化の割合を求める
            NewColor = StartColor * (1 - MoveN) + EndColor * MoveN;//線形補間で変更途中の色を求める
            Text.color = NewColor;//色を変更する
            ChangeTimer += Time.deltaTime;//経過時間を計測
            yield return new WaitForSeconds(Time.deltaTime);
        }

        //保険として最後にＴｅｘｔの色をＥｎｄＣｏｌｏｒにしておく
        Text.color = EndColor;
    }

    private void Awake(){
        Text = GetComponent<Text>();
    }

    private void Start(){
        StartCoroutine(ColorChanger());
    }

}
