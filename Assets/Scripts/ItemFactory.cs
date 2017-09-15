﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour {
    private float Timer;
    public float[] InstanceInterval;//生成間隔一覧
    public float SetInstanceInterval;//選択中の生成間隔

    //生成位置・生成物回転
    private Vector3[] InstancePos = new Vector3[] { new Vector3(15, 6, 0), new Vector3(15, 1, 0), new Vector3(15, -4, 0) };
    private Vector3 InstanceRotation = new Vector3(90, 0, 0);

    //生成物一覧
    public GameObject[] Item;

    public void Move(){
        //生成間隔を計る
        Timer += Time.deltaTime;
        if(Timer >= SetInstanceInterval){
            //生成アイテム決定
            int InstanceItemNum = Random.Range(0, Item.Length);

            //生成順路決定
            int InstanceRoteNum;
            while (true){
                InstanceRoteNum = Random.Range(0, GameRoot.Rote.Length);
                if(InstanceRoteNum != (int)CameraController.NowBackgroundColor){
                    break;//背景色と同じ色の道には生成しない
                }
            }

            //アイテム生成
            Instantiate(Item[InstanceItemNum], InstancePos[InstanceRoteNum], Quaternion.Euler(InstanceRotation));

            //タイマーリセット
            Timer = 0;
            //生成間隔をばらつかせる
            SetInstanceInterval = InstanceInterval[Random.Range(0, InstanceInterval.Length)];
        }
    }

}