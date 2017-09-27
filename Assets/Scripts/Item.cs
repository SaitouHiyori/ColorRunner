using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public enum ItemJanle {Coin,Gasoline };//アイテム種類
    public ItemJanle Janle;//選択された種類

    delegate void ItemAction();//選択式アイテム挙動
    ItemAction Action;//選択された挙動

    public float Speed;//移動速度

    public int Score;//取得スコア
    public AudioClip ItemSound;//取得音
    public GameObject SEPlayerPre;//取得音再生オブジェクト

    public float TopLimmite;
    public float UnderLimmite;

    public Vector3 Roll;
    public float AddDeg;//回転量

    public Player Player;

    //アイテムジャンル別処理
    private void ItemAction_Coin(){
        GameManager.Score = Score;
        Player.IsItemGet();
        Destroy(this.gameObject);
    }//コイン

    private void ItemAction_Gasoline(){
        Player.AddGasoline(Score);
        Player.IsItemGet();
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

        Vector3 NowPos = transform.position;

        //下に落ちると上に行く
        if (NowPos.y <= UnderLimmite){
            NowPos.y = TopLimmite;
            transform.position = NowPos;
        }


        //移動
        Vector3 Move = new Vector3(-Speed, 0, 0);
        transform.position += Move;

        //回転
        
        Roll.z += AddDeg * Time.deltaTime;
        transform.rotation = Quaternion.Euler(Roll);

    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            Player = other.gameObject.GetComponent<Player>();
            GameObject SEPlayer = Instantiate(SEPlayerPre);//効果音生成
            SEPlayer.GetComponent<AudioSource>().clip = ItemSound;//効果音設定
            SEPlayer.GetComponent<ItemGetSound>().SEPlay();//効果音再生
            Action();
        }
    }
}
