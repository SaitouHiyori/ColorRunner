using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public int Score;

    GameRoot GR;
    Attack AT;

	void Start () {
        GR = GameObject.Find("GameRoots").GetComponent<GameRoot>();
        AT = GameObject.Find("GameRoots").GetComponent<Attack>();

        Destroy(this.gameObject, Time.deltaTime);
	}

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Enemy" && AT.AttackColor == GR.NowColor){
            Destroy(other.gameObject);
            GameManager.Add_GameScore(Score);
        }
    }
}
