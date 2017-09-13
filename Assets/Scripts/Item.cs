using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public enum ItemJanle {Coin,Gasoline };
    public ItemJanle Janle;

    delegate void ItemAction();
    ItemAction Action;

    public int Score;
    public float Gasoline;

    public float Speed;

    //アイテムジャンル別処理
    private void ItemAction_Coin(){
        GameManager.Add_GameScore(Score);
        Destroy(this.gameObject);
    }//コイン

    private void ItemAction_Gasoline(){
        Player.AddGasoline(Gasoline);
        Destroy(this.gameObject);
    }//ガソリン

    private void Awake(){
        //接触時アクション決定
        switch (Janle){
            case ItemJanle.Coin:
                Action = ItemAction_Coin;
                break;
            case ItemJanle.Gasoline:
                Action = ItemAction_Gasoline;
                break;
            default:
                break;
        }
    }

	void Update () {
        //画面外退場で消滅
        if (this.transform.position.x < -15){
            Destroy(this.gameObject);
        }

        //移動
        Vector3 Move = new Vector3(-Speed, 0, 0);
        transform.position += Move;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            Action();
        }
    }
}
