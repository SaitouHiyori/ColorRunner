using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Color[] BodyColor;
    public int ColorNum;

    public float Speed;//移動速度
    public float LeftLimitte;

    public void ColorChanger(int NextColorNum){
        ColorNum = NextColorNum;

        //ColorNumの値で色が変化
        GetComponent<Renderer>().material.color = BodyColor[ColorNum];
        //GetComponent<Material>().color = BodyColor[ColorNum];

        //背景と同化したら消滅
        if (CameraController.NowColorNum == ColorNum){
            Destroy(this.gameObject);
        }
    }

    private void Awake () {
        //ランダムに色を決定
        ColorChanger(Random.Range(3, BodyColor.Length));
    }

    private void Update () {
        //画面外退場で消滅
        if(this.transform.position.x < LeftLimitte){
            Destroy(this.gameObject);
        }

        //移動
        Vector3 Move = new Vector3(-Speed, 0, 0);
        transform.position += Move;
	}

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            //Playerに触れたらゲーム終了
            Destroy(this.gameObject);
            GameManager.Set_GameFlag(false);
        }
    }
}
