using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    //敵を倒して入手できるスコア
    public int Score;

    GameRoot GR;
    Attack AT;

	void Awake () {
        Destroy(this.gameObject, Time.deltaTime);
	}

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Enemy"){
            //接触したEnemyを攻撃色に変更する
            other.GetComponent<Enemy>().ColorChanger(Attack.AttackColorNum);
        }
    }
}
