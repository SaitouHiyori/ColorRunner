using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //本体色
    private int BodyColorCount;//使用する本体色数
    public Paint.Name NowColor;//現在の本体色

    public float Speed;//移動速度
    public float LeftLimitte;//消失点

    public float TopLimmite;
    public float UnderLimmite;

    public void ColorChanger(Paint.Name NewColor){
        //色変更
        NowColor = NewColor;
        GetComponent<Renderer>().material.color = Paint.GetColor(NowColor);

    }//本体色変更メソッド

    private void Awake () {
        //本体色数取得
        BodyColorCount = System.Enum.GetNames(typeof(Paint.Name)).Length;

        //ランダムに色を決定
        int FirstColor = Random.Range(0, BodyColorCount);
        ColorChanger(Paint.Int2Name(FirstColor));
    }

    private void Update () {
        //画面外退場で消滅
        if(this.transform.position.x < LeftLimitte){
            Destroy(this.gameObject);
        }

        //背景と同化したら消滅
        if (CameraController.NowBackgroundColor == NowColor){
            Destroy(this.gameObject);
        }

        Vector3 NowPos = transform.position;

        //下に落ちると上に行く
        if (NowPos.y <= UnderLimmite){
            NowPos.y = TopLimmite;
            transform.position = NowPos;
        }


        //移動
        Vector3 Move = new Vector3(-Speed, 0, 0);
        transform.position += Move;
	}

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            //Playerに触れたらゲーム終了
            Destroy(this.gameObject);
            GameManager.Flag = false;
        }
    }
}
