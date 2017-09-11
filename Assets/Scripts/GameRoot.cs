using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour {

    public float ChangeInterval;
    float GameTimer;
    float RCTimer;//色変換中経過時間

    //色名
    const string Red   = "Red";
    const string Blue  = "Blue";
    const string Green = "Green";

    public string NowColor;//現在の色
    string NewColor;//更新する色

    bool IsRoteChage = false;

    //道
    GameObject RedRote;
    GameObject BlueRote;
    GameObject GreenRote;

    public GameObject TitleButton;
    public GameObject TitleText;
    public GameObject ResultButton;
    public GameObject ResultText;

    GameObject BehindRote;

    void ColorChanger(string ChangeColor){
        switch (ChangeColor) {
            case Red:
                Camera.main.backgroundColor = Color.red;
                break;
            case Blue:
                Camera.main.backgroundColor = Color.blue;
                break;
            case Green:
                Camera.main.backgroundColor = Color.green;
                break;
            default:
                Camera.main.backgroundColor = Color.gray;
                break;
        }
    }

    void RoteBehind(string Rote){
        BehindRote.SetActive(true);
        switch (Rote) {
            case Red:
                BehindRote = RedRote;
                break;
            case Blue:
                BehindRote = BlueRote;
                break;
            case Green:
                BehindRote = GreenRote;
                break;
        }
        BehindRote.SetActive(false);
    }

    string Choice(string NowColor){
        //色をランダム選択
        while(true){
            string NewColor = "";
            int Index = Random.Range(0, 3);
            switch (Index){
                case 0:
                    NewColor = Red;
                    break;
                case 1:
                    NewColor = Blue;
                    break;
                case 2:
                    NewColor = Green;
                    break;
                default:
                    continue;
            }
            if (NewColor != NowColor){
                //前の色と別の色を選択
                return NewColor;
            }
        }
    }

    IEnumerator Flashing(string NowColor,string NewColor){
        //点滅
        int x = 0;
        for (int i = 0; i < 10; i++){
            switch (x){
                case 0:
                    ColorChanger(NowColor);
                    break;
                case 1:
                    ColorChanger(NewColor);
                    break;
            }
            x = (x == 0) ? 1 : 0;
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator RoteChanger(string NowColor,string NewColor,GameObject BehindRote){
        StartCoroutine(Flashing(NowColor, NewColor));//点滅
        yield return new WaitForSeconds(4.5f);
        RoteBehind(NewColor);//隠す
    }

	void Start () {
        GameManager.Set_GameFlag(false);
        ColorChanger(NowColor);
        
        //道保存
        RedRote   = GameObject.Find("RedRoad");
        BlueRote  = GameObject.Find("BlueRoad");
        GreenRote = GameObject.Find("GreenRoad");

        BehindRote = RedRote;

        GameTimer = ChangeInterval;
    }
	
	void Update () {
        if (GameManager.Get_GameFlag()){
            GameTimer += Time.deltaTime;
            if (IsRoteChage){
                RCTimer += Time.deltaTime;
            }

            if (GameTimer >= ChangeInterval){
                NewColor = Choice(NowColor);
                StartCoroutine(RoteChanger(NowColor, NewColor, BehindRote));
                IsRoteChage = true;
                GameTimer = 0;
            }

            if (RCTimer >= 5){
                NowColor = NewColor;
                IsRoteChage = false;
                RCTimer = 0;
            }
        }
	}

    public void GameStart(){
        TitleButton.SetActive(false);
        TitleText.SetActive(false);
        GameManager.GameStart();
        GameTimer = ChangeInterval;
    }

    public void ReturnTitel(){
        ResultButton.SetActive(false);
        ResultText.SetActive(false);
        BehindRote.SetActive(true);
        NowColor = "";
        ColorChanger(NowColor);
        TitleButton.SetActive(true);
        TitleText.SetActive(true);
    }
}