using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float TopLimmite;
    public float UnderLimmite;

    float RedRotePos = 2 / 3;
    float BlueRotePos = 1 / 3;

    const string Red   = "Red";
    const string Blue  = "Blue";
    const string Green = "Green";

    Vector3 RedRote   = new Vector3(-8, 6, 0);
    Vector3 BlueRote  = new Vector3(-8, 1, 0);
    Vector3 GreenRote = new Vector3(-8, -4, 0);

    GameRoot GR;

	void Start () {
        GR = GameObject.Find("GameRoots").GetComponent<GameRoot>();
        transform.position = BlueRote;
    }
	
	void Update () {
        if(GameManager.Get_GameFlag() == false){
            MoveToBlue();
        }

        Vector3 NowPos = transform.position;

        //緑から落ちると上に行く
        if (NowPos.y <= UnderLimmite){
            NowPos.y = TopLimmite;
            transform.position = NowPos;
        }

        ////移動（矢印キー）
        //if (Input.GetKeyDown(KeyCode.UpArrow)){
        //    if(GR.NowColor == Red){
        //        return;
        //    }
        //    transform.position = RedRote;
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow)){
        //    if(GR.NowColor == Blue){
        //        return;
        //    }
        //    transform.position = BlueRote;
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow)){
        //    if(GR.NowColor == Green){
        //        return;
        //    }
        //    transform.position = GreenRote;
        //}
    }
    public void MoveToRed(){
        //赤へ移動
        if (GR.NowColor == Red){
            return;
        }
        transform.position = RedRote;
    }

    public void MoveToBlue(){
        //青へ移動
        if (GR.NowColor == Blue){
            return;
        }
        transform.position = BlueRote;
    }

    public void MoveToGreen(){
        //緑へ移動
        if (GR.NowColor == Green){
            return;
        }
        transform.position = GreenRote;
    }

    void OnGUI(){
        string Score = "Score:" + GameManager.Get_GameScore();

        GUI.Label(new Rect(0, 0, 100, 100), Score);
    }
}
