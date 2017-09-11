using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {
    
    const string Red   = "Red";
    const string Blue  = "Blue";
    const string Green = "Green";

    public string AttackColor;

    public Button RedAttackButton;
    public Button BlueAttackButton;
    public Button GreenAttackButton;

    GameObject Destroyer;

	void Start () {
        Destroyer = (GameObject)Resources.Load("Character/Destroyer");
    }
	
	void Update () {
        if (Input.GetButtonDown("Fire1")){
            Vector3 SelfScreenPoint = Camera.main.WorldToScreenPoint(Vector3.zero);
            Vector3 Position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, SelfScreenPoint.z));
            Instantiate(Destroyer, Position, Quaternion.identity);
        }	
	}

    public void HaveRed(){
        //赤で攻撃
        AttackColor = Red;
    }

    public void HaveBlue(){
        //青で攻撃
        AttackColor = Blue;
    }

    public void HaveGreen(){
        //緑で攻撃
        AttackColor = Green;
    }

    public void ColorReset(){
        //色を放棄
        AttackColor = "";
    }
}
