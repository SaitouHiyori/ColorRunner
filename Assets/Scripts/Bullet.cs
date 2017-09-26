using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //敵を倒して入手できるスコア
    public int Score;

    public Paint.Name AttackColor;//攻撃色
    public float DestroyTime;//生存時間
    public float Speed;//前進速度

    public void SetColor(Paint.Name SetColorName){
        AttackColor = SetColorName;
        GetComponent<Renderer>().material.color = Paint.GetColor(AttackColor);
    }

    void Awake () {
        Destroy(this.gameObject, DestroyTime);
	}

    private void Update(){
        //前進処理
        Vector3 MovePos = transform.right * Speed * Time.deltaTime;
        transform.position += MovePos;
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Enemy"){
            //接触したEnemyを攻撃色に変更する
            other.gameObject.GetComponent<Enemy>().NowColor = AttackColor;
            Destroy(this.gameObject);
        }
    }
}
