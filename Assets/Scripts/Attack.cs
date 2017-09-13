using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {
    public enum ObjectJanle {GameRote,Button }
    public ObjectJanle Janle;

    public static int AttackColorNum;
    public int SetACN;

    private GameObject Destroyer;

	void Start () {
        Destroyer = (GameObject)Resources.Load("Character/Destroyer");
    }
	
	void Update () {
        if (Janle == ObjectJanle.GameRote){
            if (Input.GetButtonDown("Fire1")){
                Vector3 SelfScreenPoint = Camera.main.WorldToScreenPoint(Vector3.zero);
                Vector3 Position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, SelfScreenPoint.z));
                Instantiate(Destroyer, Position, Quaternion.identity);
            }
        }
	}

    public void SetAttackColor(){
        AttackColorNum = SetACN;
    }

}
