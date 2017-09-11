using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour {

    int IsEnemy;

    float Timer;
    public float InstanceInterval;
    public float PerCent;

    Vector3 RedRote   = new Vector3(15, 6, 0);
    Vector3 BlueRote  = new Vector3(15, 1, 0);
    Vector3 GreenRote = new Vector3(15, -4, 0);

    Vector3 InstantRotation = new Vector3(90, 0, 0);

    GameObject[] Item = new GameObject[2];

    GameRoot GR;

    bool IsInstance(){
        int x = Random.Range(1, 101);

        if(x % PerCent == 0){
            Debug.Log("Instance");
            return true;
        }
        else{
            Debug.Log("NotInstance");
            return false;
        }
    }

    bool IsRedRote(){
        int x = Random.Range(1, 101);

        if (x % PerCent == 0){
            return true;
        }
        else {
            return false;
        }
    }

    bool IsBlueRote(){
        int x = Random.Range(1, 101);

        if (x % PerCent == 0){
            return true;
        }
        else {
            return false;
        }
    }

    bool IsGreenRote(){
        int x = Random.Range(1, 101);

        if(x % PerCent == 0){
            return true;
        }
        else{
            return false;
        }
    }

	void Start () {
        //GameObjectを保存
        Item[0] = (GameObject)Resources.Load("Character/Enemy");
        Item[1] = (GameObject)Resources.Load("Item/Coin");

        GR = GameObject.Find("GameRoots").GetComponent<GameRoot>();
    }
	
	void Update () {
        //デバッグ用フラグ
        if (GameManager.Get_GameFlag())
        {
            Timer += Time.deltaTime;

            if (Timer > InstanceInterval)
            {
                if (IsRedRote())
                {
                    if (GR.NowColor == "Red")
                    {
                        return;
                    }
                    IsEnemy = Random.Range(0, 2);
                    Instantiate(Item[IsEnemy], RedRote, Quaternion.Euler(InstantRotation));
                }
                if (IsBlueRote())
                {
                    if (GR.NowColor == "Blue")
                    {
                        return;
                    }
                    IsEnemy = Random.Range(0, 2);
                    Instantiate(Item[IsEnemy], BlueRote, Quaternion.Euler(InstantRotation));
                }
                if (IsGreenRote())
                {
                    if (GR.NowColor == "Green")
                    {
                        return;
                    }
                    IsEnemy = Random.Range(0, 2);
                    Instantiate(Item[IsEnemy], GreenRote, Quaternion.Euler(InstantRotation));
                }
                Timer = 0;
            }
        }
	}
}
