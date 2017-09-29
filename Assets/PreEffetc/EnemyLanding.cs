using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLanding : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
        //落下判定
        //Enemy_TankMain.EnemyIsFall = (GetComponent<Rigidbody>().velocity.y < 0) ? true : false;
    }
}
