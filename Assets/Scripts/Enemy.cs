using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float Speed;

    const string Red     = "Red";
    const string Blue    = "Blue";
    const string Green   = "Green";
    const string Yellow  = "Yellow";
    const string Magenta = "Magenta";
    const string Cyan    = "Cyan";

    string ColorName;

    GameRoot GR;

    void Start () {
        GR = GameObject.Find("GameRoots").GetComponent<GameRoot>();
        while (true){
            int Index = Random.Range(0, 7);
            switch (Index){
                case 0:
                    ColorName = Red;
                    if (GR.NowColor == ColorName){
                        continue;
                    }
                    GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 1:
                    ColorName = Blue;
                    if (GR.NowColor == ColorName){
                        continue;
                    }
                    GetComponent<Renderer>().material.color = Color.blue;
                    break;
                case 2:
                    ColorName = Green;
                    if (GR.NowColor == ColorName){
                        continue;
                    }
                    GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 3:
                    GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case 4:
                    GetComponent<Renderer>().material.color = Color.magenta;
                    break;
                case 5:
                    GetComponent<Renderer>().material.color = Color.cyan;
                    break;
                default:
                    GetComponent<Renderer>().material.color = Color.gray;
                    break;
            }
            break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //背景色と同化で消滅
        if(GR.NowColor == ColorName){
            Destroy(this.gameObject);
        }

        //画面外退場で消滅
        if(this.transform.position.x < -15){
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
            GameManager.GameEnd();
            GameManager.Reset_GameScore();
            GR.ResultButton.SetActive(true);
            GR.ResultText.SetActive(true);
        }
    }
}
