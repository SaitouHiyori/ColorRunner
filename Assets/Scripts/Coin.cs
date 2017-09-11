using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int Score;

    public float Speed;

	void Start () {
		
	}
	
	void Update () {
        //画面外退場で消滅
        if (this.transform.position.x < -15){
            Destroy(this.gameObject);
        }

        //ゲームオーバーで消滅
        if (GameManager.Get_GameFlag() == false){
            Destroy(this.gameObject);
        }

        Vector3 Move = new Vector3(-Speed, 0, 0);

        transform.position += Move;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            GameManager.Add_GameScore(Score);
        }
    }
}
