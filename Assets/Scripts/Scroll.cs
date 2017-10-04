using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    public float Speed; //スクロール速度

    //ランダム位置生成上限・下限
    public float HeighEnd; //上限
    public float LowEnd;   //下限

    public float ScrollStart; //スクロール開始地点
    public float ScrollEnd;   //スクロール終了地点

    private void Update(){
        //スクロール
        Vector3 MovePos = new Vector3(-Speed, 0, 0) * Time.deltaTime;
        transform.position += MovePos;

        //スクロール終了地点を過ぎたら開始地点に戻す
        if (transform.position.x < ScrollEnd)
        {
            float yPos = Random.Range(LowEnd, HeighEnd);
            Vector3 ReturnPos = new Vector3(ScrollStart, yPos, 1);
            transform.position = ReturnPos;
        }
    }

}
