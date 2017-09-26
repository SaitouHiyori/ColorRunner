using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint :MonoBehaviour  {
    //色を管理するスクリプト
    public enum Name { Red,Blue,Green,Non,Change }//名称

    private static Color[] UsePaint = new Color[] {
        new Color(0.8f, 0.2f, 0.2f),
        new Color(0.2f, 0.2f, 0.8f),
        new Color(0.2f, 0.8f, 0.2f),
        new Color(0, 0, 0),
        new Color(0, 0, 0),
    };//色

    public static Name Int2Name(int ColorNum){
        return (Name)ColorNum;
    }//int型変数をNameに変換

    public static Color GetColor(Name PaintName){
        return UsePaint[(int)PaintName];
    }//色取得メソッド

}
