using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    //プレイヤー関連のボタンを管理する

        //ボタン種類
    public enum ButtonJanle {RoteChange,SetAttackColor,Shot }//一覧
    public ButtonJanle Janle;

    public Paint.Name SetColor;//設定する値

    //挙動設定用デリゲート
    private delegate void Action();
    private Action ButtonAction;

    //各種スクリプト
    private Player Player;

    private void Start(){
        switch (Janle){
            case ButtonJanle.RoteChange:
                ButtonAction += RoteChange;
                break;
            case ButtonJanle.SetAttackColor:
                ButtonAction += SetAttackColor;
                break;
            case ButtonJanle.Shot:
                ButtonAction += Player.Shot;
                break;
            default:
                break;
        }
    }

    private void SetAttackColor(){
        Player.SetAttackColor(SetColor);
    }//攻撃色変更メソッド

    private void RoteChange(){
        Player.RoteChange(SetColor);
    }//道移動メソッド

    public void PlayerButtonAction(){
        if (GameManager.Flag){
            ButtonAction();
        }
    }

    private void Awake(){
        Player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

}
