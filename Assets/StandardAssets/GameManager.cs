using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager{

    private static int GameScore;

    private static float GameTimer;

    private static bool GameFlag;

    public static void Add_GameScore(int Score){
        GameScore += Score;
    }
    public static int Get_GameScore(){
        return GameScore;
    }
    public static void Reset_GameScore(){
        GameScore = 0;
    }

    public static void Add_GameTimer(float Time){
        GameTimer += Time;
    }
    public static float Get_GameTimer(){
        return GameTimer;
    }

    public static void Set_GameFlag(bool Flag){
        GameFlag = Flag;
    }
    public static bool Get_GameFlag(){
        return GameFlag;
    }
    public static void GameStart(){
        GameFlag = true;
    }
    public static void GameEnd(){
        GameFlag = false;
    }
}
