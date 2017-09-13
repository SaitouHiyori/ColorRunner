using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour {
    private float Timer;
    public float[] InstanceInterval;//生成間隔一覧
    public float SetInstanceInterval;//選択中の生成間隔

    //生成位置・生成物回転
    private Vector3[] InstancePos = new Vector3[] { new Vector3(15, 6, 0), new Vector3(15, 1, 0), new Vector3(15, -4, 0) };
    private Vector3 InstanceRotation = new Vector3(90, 0, 0);

    //生成物一覧
    public GameObject[] Item;

    private void Update(){
        //生成間隔を計る
        Timer += Time.deltaTime;
        if(Timer >= SetInstanceInterval){
            //生成アイテム決定
            int InstanceItemNum = Random.Range(0, Item.Length);

            //生成順路決定
            int InstanceRoteNum;
            while (true){
                InstanceRoteNum = Random.Range(0, GameRoot.Rote.Length);
                if(InstanceRoteNum != CameraController.NowColorNum){
                    break;
                }
            }

            //アイテム生成
            Instantiate(Item[InstanceItemNum], InstancePos[InstanceRoteNum], Quaternion.Euler(InstanceRotation));

            //タイマーリセット
            Timer = 0;
            //生成間隔をばらつかせる
            SetInstanceInterval = InstanceInterval[Random.Range(0, InstanceInterval.Length)];
        }
    }

    //    int IsEnemy;
    //    public float PerCent;
    //    GameRoot GR;

    //    bool IsInstance(){
    //        int x = Random.Range(1, 101);

    //        if(x % PerCent == 0){
    //            Debug.Log("Instance");
    //            return true;
    //        }
    //        else{
    //            Debug.Log("NotInstance");
    //            return false;
    //        }
    //    }

    //    bool IsRedRote(){
    //        int x = Random.Range(1, 101);

    //        if (x % PerCent == 0){
    //            return true;
    //        }
    //        else {
    //            return false;
    //        }
    //    }

    //    bool IsBlueRote(){
    //        int x = Random.Range(1, 101);

    //        if (x % PerCent == 0){
    //            return true;
    //        }
    //        else {
    //            return false;
    //        }
    //    }

    //    bool IsGreenRote(){
    //        int x = Random.Range(1, 101);

    //        if(x % PerCent == 0){
    //            return true;
    //        }
    //        else{
    //            return false;
    //        }
    //    }

    //	void Start () {
    //        //GameObjectを保存
    //        Item[0] = (GameObject)Resources.Load("Character/Enemy");
    //        Item[1] = (GameObject)Resources.Load("Item/Coin");

    //        GR = GameObject.Find("GameRoots").GetComponent<GameRoot>();
    //    }

    //	void Update () {
    //        //デバッグ用フラグ
    //        if (GameManager.Get_GameFlag())
    //        {
    //            Timer += Time.deltaTime;

    //            if (Timer > InstanceInterval)
    //            {
    //                if (IsRedRote())
    //                {
    //                    if (GR.NowColor == "Red")
    //                    {
    //                        return;
    //                    }
    //                    IsEnemy = Random.Range(0, 2);
    //                    Instantiate(Item[IsEnemy], RedRote, Quaternion.Euler(InstantRotation));
    //                }
    //                if (IsBlueRote())
    //                {
    //                    if (GR.NowColor == "Blue")
    //                    {
    //                        return;
    //                    }
    //                    IsEnemy = Random.Range(0, 2);
    //                    Instantiate(Item[IsEnemy], BlueRote, Quaternion.Euler(InstantRotation));
    //                }
    //                if (IsGreenRote())
    //                {
    //                    if (GR.NowColor == "Green")
    //                    {
    //                        return;
    //                    }
    //                    IsEnemy = Random.Range(0, 2);
    //                    Instantiate(Item[IsEnemy], GreenRote, Quaternion.Euler(InstantRotation));
    //                }
    //                Timer = 0;
    //            }
    //        }
    //	}

}